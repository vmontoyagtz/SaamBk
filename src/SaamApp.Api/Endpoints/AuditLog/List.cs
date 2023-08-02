using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AuditLog;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AuditLogEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAuditLogRequest>.WithActionResult<ListAuditLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AuditLog> _repository;

        public List(IRepository<AuditLog> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/auditLogs")]
        [SwaggerOperation(
            Summary = "List AuditLogs",
            Description = "List AuditLogs",
            OperationId = "auditLogs.List",
            Tags = new[] { "AuditLogEndpoints" })
        ]
        public override async Task<ActionResult<ListAuditLogResponse>> HandleAsync(
            [FromQuery] ListAuditLogRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAuditLogResponse(request.CorrelationId());

            var spec = new AuditLogGetListSpec();
            var auditLogs = await _repository.ListAsync(spec);
            if (auditLogs is null)
            {
                return NotFound();
            }

            response.AuditLogs = _mapper.Map<List<AuditLogDto>>(auditLogs);
            response.Count = response.AuditLogs.Count;

            return Ok(response);
        }
    }
}