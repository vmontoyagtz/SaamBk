using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.State;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.StateEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateStateRequest>.WithActionResult<UpdateStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<State> _repository;

        public Update(
            IRepository<State> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/states")]
        [SwaggerOperation(
            Summary = "Updates a State",
            Description = "Updates a State",
            OperationId = "states.update",
            Tags = new[] { "StateEndpoints" })
        ]
        public override async Task<ActionResult<UpdateStateResponse>> HandleAsync(UpdateStateRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateStateResponse(request.CorrelationId());

            var staToUpdate = _mapper.Map<State>(request);

            var stateToUpdateTest = await _repository.GetByIdAsync(request.StateId);
            if (stateToUpdateTest is null)
            {
                return NotFound();
            }

            staToUpdate.UpdateCountryForState(request.CountryId);
            await _repository.UpdateAsync(staToUpdate);

            var stateUpdatedEvent = new StateUpdatedEvent(staToUpdate, "Mongo-History");
            _messagePublisher.Publish(stateUpdatedEvent);

            var dto = _mapper.Map<StateDto>(staToUpdate);
            response.State = dto;

            return Ok(response);
        }
    }
}