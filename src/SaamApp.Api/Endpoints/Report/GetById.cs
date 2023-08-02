using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Report;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ReportEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdReportRequest>.WithActionResult<
        GetByIdReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Report> _repository;

        public GetById(
            IRepository<Report> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/reports/{ReportId}")]
        [SwaggerOperation(
            Summary = "Get a Report by Id",
            Description = "Gets a Report by Id",
            OperationId = "reports.GetById",
            Tags = new[] { "ReportEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdReportResponse>> HandleAsync(
            [FromRoute] GetByIdReportRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdReportResponse(request.CorrelationId());

            var report = await _repository.GetByIdAsync(request.ReportId);
            if (report is null)
            {
                return NotFound();
            }

            response.Report = _mapper.Map<ReportDto>(report);

            return Ok(response);
        }
    }
}