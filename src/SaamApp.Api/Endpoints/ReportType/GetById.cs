using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ReportType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ReportTypeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdReportTypeRequest>.WithActionResult<
        GetByIdReportTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ReportType> _repository;

        public GetById(
            IRepository<ReportType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/reportTypes/{ReportTypeId}")]
        [SwaggerOperation(
            Summary = "Get a ReportType by Id",
            Description = "Gets a ReportType by Id",
            OperationId = "reportTypes.GetById",
            Tags = new[] { "ReportTypeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdReportTypeResponse>> HandleAsync(
            [FromRoute] GetByIdReportTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdReportTypeResponse(request.CorrelationId());

            var reportType = await _repository.GetByIdAsync(request.ReportTypeId);
            if (reportType is null)
            {
                return NotFound();
            }

            response.ReportType = _mapper.Map<ReportTypeDto>(reportType);

            return Ok(response);
        }
    }
}