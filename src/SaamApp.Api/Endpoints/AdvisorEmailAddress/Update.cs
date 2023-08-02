using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AdvisorEmailAddressEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAdvisorEmailAddressRequest>.WithActionResult<
        UpdateAdvisorEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorEmailAddress> _repository;

        public Update(
            IRepository<AdvisorEmailAddress> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/advisorEmailAddresses")]
        [SwaggerOperation(
            Summary = "Updates a AdvisorEmailAddress",
            Description = "Updates a AdvisorEmailAddress",
            OperationId = "advisorEmailAddresses.update",
            Tags = new[] { "AdvisorEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAdvisorEmailAddressResponse>> HandleAsync(
            UpdateAdvisorEmailAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAdvisorEmailAddressResponse(request.CorrelationId());

            var aeadeaveaToUpdate = _mapper.Map<AdvisorEmailAddress>(request);

            var advisorEmailAddressToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (advisorEmailAddressToUpdateTest is null)
            {
                return NotFound();
            }

            aeadeaveaToUpdate.UpdateAdvisorForAdvisorEmailAddress(request.AdvisorId);
            aeadeaveaToUpdate.UpdateEmailAddressForAdvisorEmailAddress(request.EmailAddressId);
            aeadeaveaToUpdate.UpdateEmailAddressTypeForAdvisorEmailAddress(request.EmailAddressTypeId);
            await _repository.UpdateAsync(aeadeaveaToUpdate);

            var advisorEmailAddressUpdatedEvent =
                new AdvisorEmailAddressUpdatedEvent(aeadeaveaToUpdate, "Mongo-History");
            _messagePublisher.Publish(advisorEmailAddressUpdatedEvent);

            var dto = _mapper.Map<AdvisorEmailAddressDto>(aeadeaveaToUpdate);
            response.AdvisorEmailAddress = dto;

            return Ok(response);
        }
    }
}