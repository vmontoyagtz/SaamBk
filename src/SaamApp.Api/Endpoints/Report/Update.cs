using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Report;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.ReportEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateReportRequest>.WithActionResult<UpdateReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Report> _repository;

        public Update(
            IRepository<Report> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/reports")]
        [SwaggerOperation(
            Summary = "Updates a Report",
            Description = "Updates a Report",
            OperationId = "reports.update",
            Tags = new[] { "ReportEndpoints" })
        ]
        public override async Task<ActionResult<UpdateReportResponse>> HandleAsync(UpdateReportRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateReportResponse(request.CorrelationId());

            var repToUpdate = _mapper.Map<Report>(request);

            var reportToUpdateTest = await _repository.GetByIdAsync(request.ReportId);
            if (reportToUpdateTest is null)
            {
                return NotFound();
            }

            repToUpdate.UpdateReportTypeForReport(request.ReportTypeId);
            await _repository.UpdateAsync(repToUpdate);

            var reportUpdatedEvent = new ReportUpdatedEvent(repToUpdate, "Mongo-History");
            _messagePublisher.Publish(reportUpdatedEvent);

            var dto = _mapper.Map<ReportDto>(repToUpdate);
            response.Report = dto;

            return Ok(response);
        }
    }
}