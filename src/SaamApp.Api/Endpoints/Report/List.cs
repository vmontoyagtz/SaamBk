using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListReportRequest>.WithActionResult<ListReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Report> _repository;

        public List(IRepository<Report> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/reports")]
        [SwaggerOperation(
            Summary = "List Reports",
            Description = "List Reports",
            OperationId = "reports.List",
            Tags = new[] { "ReportEndpoints" })
        ]
        public override async Task<ActionResult<ListReportResponse>> HandleAsync([FromQuery] ListReportRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListReportResponse(request.CorrelationId());

            var spec = new ReportGetListSpec();
            var reports = await _repository.ListAsync(spec);
            if (reports is null)
            {
                return NotFound();
            }

            response.Reports = _mapper.Map<List<ReportDto>>(reports);
            response.Count = response.Reports.Count;

            return Ok(response);
        }
    }
}