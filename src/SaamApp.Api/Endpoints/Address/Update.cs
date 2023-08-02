using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Address;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AddressEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAddressRequest>.WithActionResult<UpdateAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Address> _repository;

        public Update(
            IRepository<Address> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/addresses")]
        [SwaggerOperation(
            Summary = "Updates a Address",
            Description = "Updates a Address",
            OperationId = "addresses.update",
            Tags = new[] { "AddressEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAddressResponse>> HandleAsync(UpdateAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateAddressResponse(request.CorrelationId());

            var addToUpdate = _mapper.Map<Address>(request);

            var addressToUpdateTest = await _repository.GetByIdAsync(request.AddressId);
            if (addressToUpdateTest is null)
            {
                return NotFound();
            }

            //// addToUpdate.UpdateCityForAddress(request.CityId);
            // addToUpdate.UpdateCountryForAddress(request.CountryId);
            // addToUpdate.UpdateRegionForAddress(request.RegionId);
            // addToUpdate.UpdateStateForAddress(request.StateId);
            await _repository.UpdateAsync(addToUpdate);

            var addressUpdatedEvent = new AddressUpdatedEvent(addToUpdate, "Mongo-History");
            _messagePublisher.Publish(addressUpdatedEvent);

            var dto = _mapper.Map<AddressDto>(addToUpdate);
            response.Address = dto;

            return Ok(response);
        }
    }
}