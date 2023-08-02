using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Report;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ReportEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdReportRequest>.WithActionResult<
        GetByIdReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Report> _repository;

        public GetByIdWithIncludes(
            IRepository<Report> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/reports/i/{ReportId}")]
        [SwaggerOperation(
            Summary = "Get a Report by Id With Includes",
            Description = "Gets a Report by Id With Includes",
            OperationId = "reports.GetByIdWithIncludes",
            Tags = new[] { "ReportEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdReportResponse>> HandleAsync(
            [FromRoute] GetByIdReportRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdReportResponse(request.CorrelationId());

            var spec = new ReportByIdWithIncludesSpec(request.ReportId);

            var report = await _repository.FirstOrDefaultAsync(spec);


            if (report is null)
            {
                return NotFound();
            }

            response.Report = _mapper.Map<ReportDto>(report);

            return Ok(response);
        }
    }
}