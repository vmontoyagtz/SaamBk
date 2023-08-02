using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ReportType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.ReportTypeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateReportTypeRequest>.WithActionResult<
        UpdateReportTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<ReportType> _repository;

        public Update(
            IRepository<ReportType> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/reportTypes")]
        [SwaggerOperation(
            Summary = "Updates a ReportType",
            Description = "Updates a ReportType",
            OperationId = "reportTypes.update",
            Tags = new[] { "ReportTypeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateReportTypeResponse>> HandleAsync(UpdateReportTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateReportTypeResponse(request.CorrelationId());

            var rtetptToUpdate = _mapper.Map<ReportType>(request);

            var reportTypeToUpdateTest = await _repository.GetByIdAsync(request.ReportTypeId);
            if (reportTypeToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(rtetptToUpdate);

            var reportTypeUpdatedEvent = new ReportTypeUpdatedEvent(rtetptToUpdate, "Mongo-History");
            _messagePublisher.Publish(reportTypeUpdatedEvent);

            var dto = _mapper.Map<ReportTypeDto>(rtetptToUpdate);
            response.ReportType = dto;

            return Ok(response);
        }
    }
}