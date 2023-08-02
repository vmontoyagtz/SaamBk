using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AuditLog;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AuditLogEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAuditLogRequest>.WithActionResult<
        CreateAuditLogResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AuditLog> _repository;

        public Create(
            IRepository<AuditLog> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/auditLogs")]
        [SwaggerOperation(
            Summary = "Creates a new AuditLog",
            Description = "Creates a new AuditLog",
            OperationId = "auditLogs.create",
            Tags = new[] { "AuditLogEndpoints" })
        ]
        public override async Task<ActionResult<CreateAuditLogResponse>> HandleAsync(
            CreateAuditLogRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAuditLogResponse(request.CorrelationId());


            var newAuditLog = new AuditLog(
                Guid.NewGuid(),
                request.EventDateUTC,
                request.ApplicationUserId,
                request.UserName,
                request.UserRoles,
                request.TenantId,
                request.EventType,
                request.TableName,
                request.RecordId,
                request.OperationType,
                request.OldValues,
                request.NewValues,
                request.ChangesMade,
                request.ChangeReason,
                request.OperationResult,
                request.AffectedFields,
                request.IpAddress,
                request.UserAgent,
                request.AdditionalInfo
            );


            await _repository.AddAsync(newAuditLog);

            _logger.LogInformation(
                $"AuditLog created  with Id {newAuditLog.AuditLogId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AuditLogDto>(newAuditLog);

            var auditLogCreatedEvent = new AuditLogCreatedEvent(newAuditLog, "Mongo-History");
            _messagePublisher.Publish(auditLogCreatedEvent);

            response.AuditLog = dto;


            return Ok(response);
        }
    }
}