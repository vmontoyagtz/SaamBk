using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AuditLog;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AuditLogEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAuditLogRequest>.WithActionResult<
        DeleteAuditLogResponse>
    {
        private readonly IRepository<AuditLog> _auditLogReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AuditLog> _repository;

        public Delete(IRepository<AuditLog> AuditLogRepository, IRepository<AuditLog> AuditLogReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AuditLogRepository;
            _auditLogReadRepository = AuditLogReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/auditLogs/{AuditLogId}")]
        [SwaggerOperation(
            Summary = "Deletes an AuditLog",
            Description = "Deletes an AuditLog",
            OperationId = "auditLogs.delete",
            Tags = new[] { "AuditLogEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAuditLogResponse>> HandleAsync(
            [FromRoute] DeleteAuditLogRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAuditLogResponse(request.CorrelationId());

            var auditLog = await _auditLogReadRepository.GetByIdAsync(request.AuditLogId);

            if (auditLog == null)
            {
                return NotFound();
            }


            var auditLogDeletedEvent = new AuditLogDeletedEvent(auditLog, "Mongo-History");
            _messagePublisher.Publish(auditLogDeletedEvent);

            await _repository.DeleteAsync(auditLog);

            return Ok(response);
        }
    }
}