using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Report;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ReportEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateReportRequest>.WithActionResult<
        CreateReportResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<ReportType> _reportTypeRepository;
        private readonly IRepository<Report> _repository;

        public Create(
            IRepository<Report> repository,
            IRepository<ReportType> reportTypeRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _reportTypeRepository = reportTypeRepository;
        }

        [HttpPost("api/reports")]
        [SwaggerOperation(
            Summary = "Creates a new Report",
            Description = "Creates a new Report",
            OperationId = "reports.create",
            Tags = new[] { "ReportEndpoints" })
        ]
        public override async Task<ActionResult<CreateReportResponse>> HandleAsync(
            CreateReportRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateReportResponse(request.CorrelationId());

            //var reportType = await _reportTypeRepository.GetByIdAsync(request.ReportTypeId);// parent entity

            var newReport = new Report(
                Guid.NewGuid(),
                request.ReportTypeId,
                request.TenantId,
                request.ReportName,
                request.Module,
                request.IsListReport,
                request.IsFormReport,
                request.Description,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.IsActive,
                request.ReportJson,
                request.FrontEndMethodToCall,
                request.ApiMethodToCall,
                request.ParametersJson
            );


            await _repository.AddAsync(newReport);

            _logger.LogInformation(
                $"Report created  with Id {newReport.ReportId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<ReportDto>(newReport);

            var reportCreatedEvent = new ReportCreatedEvent(newReport, "Mongo-History");
            _messagePublisher.Publish(reportCreatedEvent);

            response.Report = dto;


            return Ok(response);
        }
    }
}