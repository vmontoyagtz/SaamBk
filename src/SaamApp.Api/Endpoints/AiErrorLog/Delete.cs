using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiErrorLog;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiErrorLogEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAiErrorLogRequest>.WithActionResult<
        DeleteAiErrorLogResponse>
    {
        private readonly IRepository<AiErrorLog> _aiErrorLogReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiErrorLog> _repository;

        public Delete(IRepository<AiErrorLog> AiErrorLogRepository, IRepository<AiErrorLog> AiErrorLogReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AiErrorLogRepository;
            _aiErrorLogReadRepository = AiErrorLogReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/aiErrorLogs/{AiErrorLogId}")]
        [SwaggerOperation(
            Summary = "Deletes an AiErrorLog",
            Description = "Deletes an AiErrorLog",
            OperationId = "aiErrorLogs.delete",
            Tags = new[] { "AiErrorLogEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAiErrorLogResponse>> HandleAsync(
            [FromRoute] DeleteAiErrorLogRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAiErrorLogResponse(request.CorrelationId());

            var aiErrorLog = await _aiErrorLogReadRepository.GetByIdAsync(request.AiErrorLogId);

            if (aiErrorLog == null)
            {
                return NotFound();
            }


            var aiErrorLogDeletedEvent = new AiErrorLogDeletedEvent(aiErrorLog, "Mongo-History");
            _messagePublisher.Publish(aiErrorLogDeletedEvent);

            await _repository.DeleteAsync(aiErrorLog);

            return Ok(response);
        }
    }
}