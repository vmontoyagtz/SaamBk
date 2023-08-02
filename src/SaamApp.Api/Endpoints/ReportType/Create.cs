using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.ReportType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ReportTypeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateReportTypeRequest>.WithActionResult<
        CreateReportTypeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<ReportType> _repository;

        public Create(
            IRepository<ReportType> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/reportTypes")]
        [SwaggerOperation(
            Summary = "Creates a new ReportType",
            Description = "Creates a new ReportType",
            OperationId = "reportTypes.create",
            Tags = new[] { "ReportTypeEndpoints" })
        ]
        public override async Task<ActionResult<CreateReportTypeResponse>> HandleAsync(
            CreateReportTypeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateReportTypeResponse(request.CorrelationId());


            var newReportType = new ReportType(
                Guid.NewGuid(),
                request.ReportTypeName,
                request.ReportTypeDescription,
                request.TenantId
            );


            await _repository.AddAsync(newReportType);

            _logger.LogInformation(
                $"ReportType created  with Id {newReportType.ReportTypeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<ReportTypeDto>(newReportType);

            var reportTypeCreatedEvent = new ReportTypeCreatedEvent(newReportType, "Mongo-History");
            _messagePublisher.Publish(reportTypeCreatedEvent);

            response.ReportType = dto;


            return Ok(response);
        }
    }
}