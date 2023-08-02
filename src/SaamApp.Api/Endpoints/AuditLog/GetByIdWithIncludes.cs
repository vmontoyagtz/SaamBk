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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAuditLogRequest>.WithActionResult<
        GetByIdAuditLogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AuditLog> _repository;

        public GetByIdWithIncludes(
            IRepository<AuditLog> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/auditLogs/i/{AuditLogId}")]
        [SwaggerOperation(
            Summary = "Get a AuditLog by Id With Includes",
            Description = "Gets a AuditLog by Id With Includes",
            OperationId = "auditLogs.GetByIdWithIncludes",
            Tags = new[] { "AuditLogEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAuditLogResponse>> HandleAsync(
            [FromRoute] GetByIdAuditLogRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAuditLogResponse(request.CorrelationId());

            var spec = new AuditLogByIdWithIncludesSpec(request.AuditLogId);

            var auditLog = await _repository.FirstOrDefaultAsync(spec);


            if (auditLog is null)
            {
                return NotFound();
            }

            response.AuditLog = _mapper.Map<AuditLogDto>(auditLog);

            return Ok(response);
        }
    }
}