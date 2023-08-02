using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Advisor;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AdvisorEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAdvisorRequest>.WithActionResult<UpdateAdvisorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Advisor> _repository;

        public Update(
            IRepository<Advisor> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/advisors")]
        [SwaggerOperation(
            Summary = "Updates a Advisor",
            Description = "Updates a Advisor",
            OperationId = "advisors.update",
            Tags = new[] { "AdvisorEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAdvisorResponse>> HandleAsync(UpdateAdvisorRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateAdvisorResponse(request.CorrelationId());

            var advToUpdate = _mapper.Map<Advisor>(request);

            var advisorToUpdateTest = await _repository.GetByIdAsync(request.AdvisorId);
            if (advisorToUpdateTest is null)
            {
                return NotFound();
            }

            advToUpdate.UpdateBusinessUnitForAdvisor(request.BusinessUnitId);
            advToUpdate.UpdateGenderForAdvisor(request.GenderId);
            advToUpdate.UpdatePaymentFrequencyForAdvisor(request.PaymentFrequencyId);
            advToUpdate.UpdateTaxInformationForAdvisor(request.TaxInformationId);
            await _repository.UpdateAsync(advToUpdate);

            var advisorUpdatedEvent = new AdvisorUpdatedEvent(advToUpdate, "Mongo-History");
            _messagePublisher.Publish(advisorUpdatedEvent);

            var dto = _mapper.Map<AdvisorDto>(advToUpdate);
            response.Advisor = dto;

            return Ok(response);
        }
    }
}