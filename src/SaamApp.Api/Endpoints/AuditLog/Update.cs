using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AuditLog;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AuditLogEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAuditLogRequest>.WithActionResult<UpdateAuditLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AuditLog> _repository;

        public Update(
            IRepository<AuditLog> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/auditLogs")]
        [SwaggerOperation(
            Summary = "Updates a AuditLog",
            Description = "Updates a AuditLog",
            OperationId = "auditLogs.update",
            Tags = new[] { "AuditLogEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAuditLogResponse>> HandleAsync(UpdateAuditLogRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateAuditLogResponse(request.CorrelationId());

            var aluldlToUpdate = _mapper.Map<AuditLog>(request);

            var auditLogToUpdateTest = await _repository.GetByIdAsync(request.AuditLogId);
            if (auditLogToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(aluldlToUpdate);

            var auditLogUpdatedEvent = new AuditLogUpdatedEvent(aluldlToUpdate, "Mongo-History");
            _messagePublisher.Publish(auditLogUpdatedEvent);

            var dto = _mapper.Map<AuditLogDto>(aluldlToUpdate);
            response.AuditLog = dto;

            return Ok(response);
        }
    }
}