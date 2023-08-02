using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.State;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.StateEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteStateRequest>.WithActionResult<
        DeleteStateResponse>
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<State> _repository;
        private readonly IRepository<State> _stateReadRepository;

        public Delete(IRepository<State> StateRepository, IRepository<State> StateReadRepository,
            IRepository<Address> addressRepository,
            IRepository<City> cityRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = StateRepository;
            _stateReadRepository = StateReadRepository;
            _addressRepository = addressRepository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/states/{StateId}")]
        [SwaggerOperation(
            Summary = "Deletes an State",
            Description = "Deletes an State",
            OperationId = "states.delete",
            Tags = new[] { "StateEndpoints" })
        ]
        public override async Task<ActionResult<DeleteStateResponse>> HandleAsync(
            [FromRoute] DeleteStateRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteStateResponse(request.CorrelationId());

            var state = await _stateReadRepository.GetByIdAsync(request.StateId);

            if (state == null)
            {
                return NotFound();
            }

            var addressSpec = new GetAddressWithStateKeySpec(state.StateId);
            var addresses = await _addressRepository.ListAsync(addressSpec);
            await _addressRepository.DeleteRangeAsync(addresses); // you could use soft delete with IsDeleted = true
            var citySpec = new GetCityWithStateKeySpec(state.StateId);
            var cities = await _cityRepository.ListAsync(citySpec);
            await _cityRepository.DeleteRangeAsync(cities); // you could use soft delete with IsDeleted = true

            var stateDeletedEvent = new StateDeletedEvent(state, "Mongo-History");
            _messagePublisher.Publish(stateDeletedEvent);

            await _repository.DeleteAsync(state);

            return Ok(response);
        }
    }
}