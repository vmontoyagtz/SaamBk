using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ReportType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ReportTypeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteReportTypeRequest>.WithActionResult<
        DeleteReportTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Report> _reportRepository;
        private readonly IRepository<ReportType> _reportTypeReadRepository;
        private readonly IRepository<ReportType> _repository;

        public Delete(IRepository<ReportType> ReportTypeRepository, IRepository<ReportType> ReportTypeReadRepository,
            IRepository<Report> reportRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = ReportTypeRepository;
            _reportTypeReadRepository = ReportTypeReadRepository;
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/reportTypes/{ReportTypeId}")]
        [SwaggerOperation(
            Summary = "Deletes an ReportType",
            Description = "Deletes an ReportType",
            OperationId = "reportTypes.delete",
            Tags = new[] { "ReportTypeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteReportTypeResponse>> HandleAsync(
            [FromRoute] DeleteReportTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteReportTypeResponse(request.CorrelationId());

            var reportType = await _reportTypeReadRepository.GetByIdAsync(request.ReportTypeId);

            if (reportType == null)
            {
                return NotFound();
            }

            var reportSpec = new GetReportWithReportTypeKeySpec(reportType.ReportTypeId);
            var reports = await _reportRepository.ListAsync(reportSpec);
            await _reportRepository.DeleteRangeAsync(reports); // you could use soft delete with IsDeleted = true

            var reportTypeDeletedEvent = new ReportTypeDeletedEvent(reportType, "Mongo-History");
            _messagePublisher.Publish(reportTypeDeletedEvent);

            await _repository.DeleteAsync(reportType);

            return Ok(response);
        }
    }
}