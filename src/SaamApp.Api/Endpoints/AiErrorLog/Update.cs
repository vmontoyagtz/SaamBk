using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiErrorLog;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AiErrorLogEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAiErrorLogRequest>.WithActionResult<
        UpdateAiErrorLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiErrorLog> _repository;

        public Update(
            IRepository<AiErrorLog> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/aiErrorLogs")]
        [SwaggerOperation(
            Summary = "Updates a AiErrorLog",
            Description = "Updates a AiErrorLog",
            OperationId = "aiErrorLogs.update",
            Tags = new[] { "AiErrorLogEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAiErrorLogResponse>> HandleAsync(UpdateAiErrorLogRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateAiErrorLogResponse(request.CorrelationId());

            var aelielelToUpdate = _mapper.Map<AiErrorLog>(request);

            var aiErrorLogToUpdateTest = await _repository.GetByIdAsync(request.AiErrorLogId);
            if (aiErrorLogToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(aelielelToUpdate);

            var aiErrorLogUpdatedEvent = new AiErrorLogUpdatedEvent(aelielelToUpdate, "Mongo-History");
            _messagePublisher.Publish(aiErrorLogUpdatedEvent);

            var dto = _mapper.Map<AiErrorLogDto>(aelielelToUpdate);
            response.AiErrorLog = dto;

            return Ok(response);
        }
    }
}