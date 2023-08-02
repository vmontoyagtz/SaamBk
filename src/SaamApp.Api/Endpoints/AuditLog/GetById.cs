using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AuditLog;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AuditLogEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAuditLogRequest>.WithActionResult<
        GetByIdAuditLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AuditLog> _repository;

        public GetById(
            IRepository<AuditLog> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/auditLogs/{AuditLogId}")]
        [SwaggerOperation(
            Summary = "Get a AuditLog by Id",
            Description = "Gets a AuditLog by Id",
            OperationId = "auditLogs.GetById",
            Tags = new[] { "AuditLogEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAuditLogResponse>> HandleAsync(
            [FromRoute] GetByIdAuditLogRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAuditLogResponse(request.CorrelationId());

            var auditLog = await _repository.GetByIdAsync(request.AuditLogId);
            if (auditLog is null)
            {
                return NotFound();
            }

            response.AuditLog = _mapper.Map<AuditLogDto>(auditLog);

            return Ok(response);
        }
    }
}