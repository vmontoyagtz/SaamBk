using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.FinancialAccountingPeriodEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateFinancialAccountingPeriodRequest>.WithActionResult<
        CreateFinancialAccountingPeriodResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<FinancialAccountingPeriod> _repository;

        public Create(
            IRepository<FinancialAccountingPeriod> repository,
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

        [HttpPost("api/financialAccountingPeriods")]
        [SwaggerOperation(
            Summary = "Creates a new FinancialAccountingPeriod",
            Description = "Creates a new FinancialAccountingPeriod",
            OperationId = "financialAccountingPeriods.create",
            Tags = new[] { "FinancialAccountingPeriodEndpoints" })
        ]
        public override async Task<ActionResult<CreateFinancialAccountingPeriodResponse>> HandleAsync(
            CreateFinancialAccountingPeriodRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateFinancialAccountingPeriodResponse(request.CorrelationId());


            var newFinancialAccountingPeriod = new FinancialAccountingPeriod(
                Guid.NewGuid(),
                request.AccountingPeriod,
                request.PeriodStartDate,
                request.PeriodEndDate,
                request.CreatedAt,
                request.ZippedStatementsUrl,
                request.ZippedStatementsSharedAccessSignatureUrl,
                request.IsStatementsJobRunning,
                request.SettingsJson,
                request.TenantId
            );


            await _repository.AddAsync(newFinancialAccountingPeriod);

            _logger.LogInformation(
                $"FinancialAccountingPeriod created  with Id {newFinancialAccountingPeriod.FinancialAccountingPeriodId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<FinancialAccountingPeriodDto>(newFinancialAccountingPeriod);

            var financialAccountingPeriodCreatedEvent =
                new FinancialAccountingPeriodCreatedEvent(newFinancialAccountingPeriod, "Mongo-History");
            _messagePublisher.Publish(financialAccountingPeriodCreatedEvent);

            response.FinancialAccountingPeriod = dto;


            return Ok(response);
        }
    }
}