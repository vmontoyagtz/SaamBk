using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.InteractionType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.InteractionTypeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateInteractionTypeRequest>.WithActionResult<
        UpdateInteractionTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<InteractionType> _repository;

        public Update(
            IRepository<InteractionType> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/interactionTypes")]
        [SwaggerOperation(
            Summary = "Updates a InteractionType",
            Description = "Updates a InteractionType",
            OperationId = "interactionTypes.update",
            Tags = new[] { "InteractionTypeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateInteractionTypeResponse>> HandleAsync(
            UpdateInteractionTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateInteractionTypeResponse(request.CorrelationId());

            var itntttToUpdate = _mapper.Map<InteractionType>(request);

            var interactionTypeToUpdateTest = await _repository.GetByIdAsync(request.InteractionTypeId);
            if (interactionTypeToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(itntttToUpdate);

            var interactionTypeUpdatedEvent = new InteractionTypeUpdatedEvent(itntttToUpdate, "Mongo-History");
            _messagePublisher.Publish(interactionTypeUpdatedEvent);

            var dto = _mapper.Map<InteractionTypeDto>(itntttToUpdate);
            response.InteractionType = dto;

            return Ok(response);
        }
    }
}