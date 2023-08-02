using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorBank;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AdvisorBankEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAdvisorBankRequest>.WithActionResult<
        UpdateAdvisorBankResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorBank> _repository;

        public Update(
            IRepository<AdvisorBank> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/advisorBanks")]
        [SwaggerOperation(
            Summary = "Updates a AdvisorBank",
            Description = "Updates a AdvisorBank",
            OperationId = "advisorBanks.update",
            Tags = new[] { "AdvisorBankEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAdvisorBankResponse>> HandleAsync(
            UpdateAdvisorBankRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAdvisorBankResponse(request.CorrelationId());

            var abdbvbToUpdate = _mapper.Map<AdvisorBank>(request);

            var advisorBankToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (advisorBankToUpdateTest is null)
            {
                return NotFound();
            }

            abdbvbToUpdate.UpdateAdvisorForAdvisorBank(request.AdvisorId);
            abdbvbToUpdate.UpdateBankAccountForAdvisorBank(request.BankAccountId);
            await _repository.UpdateAsync(abdbvbToUpdate);

            var advisorBankUpdatedEvent = new AdvisorBankUpdatedEvent(abdbvbToUpdate, "Mongo-History");
            _messagePublisher.Publish(advisorBankUpdatedEvent);

            var dto = _mapper.Map<AdvisorBankDto>(abdbvbToUpdate);
            response.AdvisorBank = dto;

            return Ok(response);
        }
    }
}