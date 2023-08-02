using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AdvisorAddressEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAdvisorAddressRequest>.WithActionResult<
        UpdateAdvisorAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorAddress> _repository;

        public Update(
            IRepository<AdvisorAddress> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/advisorAddresses")]
        [SwaggerOperation(
            Summary = "Updates a AdvisorAddress",
            Description = "Updates a AdvisorAddress",
            OperationId = "advisorAddresses.update",
            Tags = new[] { "AdvisorAddressEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAdvisorAddressResponse>> HandleAsync(
            UpdateAdvisorAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAdvisorAddressResponse(request.CorrelationId());

            var aadavaToUpdate = _mapper.Map<AdvisorAddress>(request);

            var advisorAddressToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (advisorAddressToUpdateTest is null)
            {
                return NotFound();
            }

            aadavaToUpdate.UpdateAddressForAdvisorAddress(request.AddressId);
            aadavaToUpdate.UpdateAddressTypeForAdvisorAddress(request.AddressTypeId);
            aadavaToUpdate.UpdateAdvisorForAdvisorAddress(request.AdvisorId);
            await _repository.UpdateAsync(aadavaToUpdate);

            var advisorAddressUpdatedEvent = new AdvisorAddressUpdatedEvent(aadavaToUpdate, "Mongo-History");
            _messagePublisher.Publish(advisorAddressUpdatedEvent);

            var dto = _mapper.Map<AdvisorAddressDto>(aadavaToUpdate);
            response.AdvisorAddress = dto;

            return Ok(response);
        }
    }
}