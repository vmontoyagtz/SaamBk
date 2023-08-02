using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiInteraction;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AiInteractionEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAiInteractionRequest>.WithActionResult<
        UpdateAiInteractionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiInteraction> _repository;

        public Update(
            IRepository<AiInteraction> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/aiInteractions")]
        [SwaggerOperation(
            Summary = "Updates a AiInteraction",
            Description = "Updates a AiInteraction",
            OperationId = "aiInteractions.update",
            Tags = new[] { "AiInteractionEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAiInteractionResponse>> HandleAsync(
            UpdateAiInteractionRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAiInteractionResponse(request.CorrelationId());

            var aiiiiToUpdate = _mapper.Map<AiInteraction>(request);

            var aiInteractionToUpdateTest = await _repository.GetByIdAsync(request.AiInteractionId);
            if (aiInteractionToUpdateTest is null)
            {
                return NotFound();
            }

            aiiiiToUpdate.UpdateCustomerForAiInteraction(request.CustomerId);
            aiiiiToUpdate.UpdateAiRobotForAiInteraction(request.AiRobotId);
            aiiiiToUpdate.UpdateUserSessionForAiInteraction(request.SessionId);
            await _repository.UpdateAsync(aiiiiToUpdate);

            var aiInteractionUpdatedEvent = new AiInteractionUpdatedEvent(aiiiiToUpdate, "Mongo-History");
            _messagePublisher.Publish(aiInteractionUpdatedEvent);

            var dto = _mapper.Map<AiInteractionDto>(aiiiiToUpdate);
            response.AiInteraction = dto;

            return Ok(response);
        }
    }
}