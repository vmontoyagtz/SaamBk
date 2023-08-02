using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Report;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ReportEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteReportRequest>.WithActionResult<
        DeleteReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Report> _reportReadRepository;
        private readonly IRepository<Report> _repository;

        public Delete(IRepository<Report> ReportRepository, IRepository<Report> ReportReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = ReportRepository;
            _reportReadRepository = ReportReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/reports/{ReportId}")]
        [SwaggerOperation(
            Summary = "Deletes an Report",
            Description = "Deletes an Report",
            OperationId = "reports.delete",
            Tags = new[] { "ReportEndpoints" })
        ]
        public override async Task<ActionResult<DeleteReportResponse>> HandleAsync(
            [FromRoute] DeleteReportRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteReportResponse(request.CorrelationId());

            var report = await _reportReadRepository.GetByIdAsync(request.ReportId);

            if (report == null)
            {
                return NotFound();
            }


            var reportDeletedEvent = new ReportDeletedEvent(report, "Mongo-History");
            _messagePublisher.Publish(reportDeletedEvent);

            await _repository.DeleteAsync(report);

            return Ok(response);
        }
    }
}