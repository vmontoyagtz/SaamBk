using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AdvisorBankTransferInfoEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAdvisorBankTransferInfoRequest>.WithActionResult<
        UpdateAdvisorBankTransferInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorBankTransferInfo> _repository;

        public Update(
            IRepository<AdvisorBankTransferInfo> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/advisorBankTransferInfoes")]
        [SwaggerOperation(
            Summary = "Updates a AdvisorBankTransferInfo",
            Description = "Updates a AdvisorBankTransferInfo",
            OperationId = "advisorBankTransferInfoes.update",
            Tags = new[] { "AdvisorBankTransferInfoEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAdvisorBankTransferInfoResponse>> HandleAsync(
            UpdateAdvisorBankTransferInfoRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAdvisorBankTransferInfoResponse(request.CorrelationId());

            var abtidbtivbtiToUpdate = _mapper.Map<AdvisorBankTransferInfo>(request);

            var advisorBankTransferInfoToUpdateTest = await _repository.GetByIdAsync(request.AdvisorBankTransferInfoId);
            if (advisorBankTransferInfoToUpdateTest is null)
            {
                return NotFound();
            }

            abtidbtivbtiToUpdate.UpdateAdvisorForAdvisorBankTransferInfo(request.AdvisorId);
            abtidbtivbtiToUpdate.UpdateBankAccountForAdvisorBankTransferInfo(request.BankAccountId);
            await _repository.UpdateAsync(abtidbtivbtiToUpdate);

            var advisorBankTransferInfoUpdatedEvent =
                new AdvisorBankTransferInfoUpdatedEvent(abtidbtivbtiToUpdate, "Mongo-History");
            _messagePublisher.Publish(advisorBankTransferInfoUpdatedEvent);

            var dto = _mapper.Map<AdvisorBankTransferInfoDto>(abtidbtivbtiToUpdate);
            response.AdvisorBankTransferInfo = dto;

            return Ok(response);
        }
    }
}