using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiSession;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AiSessionEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAiSessionRequest>.WithActionResult<
        UpdateAiSessionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiSession> _repository;

        public Update(
            IRepository<AiSession> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/aiSessions")]
        [SwaggerOperation(
            Summary = "Updates a AiSession",
            Description = "Updates a AiSession",
            OperationId = "aiSessions.update",
            Tags = new[] { "AiSessionEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAiSessionResponse>> HandleAsync(UpdateAiSessionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateAiSessionResponse(request.CorrelationId());

            var asissToUpdate = _mapper.Map<AiSession>(request);

            var aiSessionToUpdateTest = await _repository.GetByIdAsync(request.AiSessionId);
            if (aiSessionToUpdateTest is null)
            {
                return NotFound();
            }

            asissToUpdate.UpdateCustomerForAiSession(request.CustomerId);
            await _repository.UpdateAsync(asissToUpdate);

            var aiSessionUpdatedEvent = new AiSessionUpdatedEvent(asissToUpdate, "Mongo-History");
            _messagePublisher.Publish(aiSessionUpdatedEvent);

            var dto = _mapper.Map<AiSessionDto>(asissToUpdate);
            response.AiSession = dto;

            return Ok(response);
        }
    }
}