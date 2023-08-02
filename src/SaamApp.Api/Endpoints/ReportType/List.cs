using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ReportType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ReportTypeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListReportTypeRequest>.WithActionResult<ListReportTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ReportType> _repository;

        public List(IRepository<ReportType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/reportTypes")]
        [SwaggerOperation(
            Summary = "List ReportTypes",
            Description = "List ReportTypes",
            OperationId = "reportTypes.List",
            Tags = new[] { "ReportTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListReportTypeResponse>> HandleAsync(
            [FromQuery] ListReportTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListReportTypeResponse(request.CorrelationId());

            var spec = new ReportTypeGetListSpec();
            var reportTypes = await _repository.ListAsync(spec);
            if (reportTypes is null)
            {
                return NotFound();
            }

            response.ReportTypes = _mapper.Map<List<ReportTypeDto>>(reportTypes);
            response.Count = response.ReportTypes.Count;

            return Ok(response);
        }
    }
}