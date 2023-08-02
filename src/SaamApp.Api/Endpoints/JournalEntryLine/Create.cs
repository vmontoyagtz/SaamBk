using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.JournalEntryLine;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.JournalEntryLineEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateJournalEntryLineRequest>.WithActionResult<
        CreateJournalEntryLineResponse>
    {
        private readonly IRepository<Account> _accountRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<JournalEntryLine> _repository;

        public Create(
            IRepository<JournalEntryLine> repository,
            IRepository<Account> accountRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _accountRepository = accountRepository;
        }

        [HttpPost("api/journalEntryLines")]
        [SwaggerOperation(
            Summary = "Creates a new JournalEntryLine",
            Description = "Creates a new JournalEntryLine",
            OperationId = "journalEntryLines.create",
            Tags = new[] { "JournalEntryLineEndpoints" })
        ]
        public override async Task<ActionResult<CreateJournalEntryLineResponse>> HandleAsync(
            CreateJournalEntryLineRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateJournalEntryLineResponse(request.CorrelationId());

            //var account = await _accountRepository.GetByIdAsync(request.AccountId);// parent entity

            var newJournalEntryLine = new JournalEntryLine(
                Guid.NewGuid(),
                request.AccountId,
                request.FinancialAccountingPeriodId,
                request.JournalEntryId,
                request.TaxAmount,
                request.Amount,
                request.JournalEntryTypeRefId,
                request.JournalEntryTypeName,
                request.IsDebit,
                request.IsCredit,
                request.CreatedBy,
                request.CreatedAt,
                request.UpdatedAt,
                request.UpdatedBy,
                request.Notes,
                request.TenantId
            );


            await _repository.AddAsync(newJournalEntryLine);

            _logger.LogInformation(
                $"JournalEntryLine created  with Id {newJournalEntryLine.JournalEntryLineId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<JournalEntryLineDto>(newJournalEntryLine);

            var journalEntryLineCreatedEvent = new JournalEntryLineCreatedEvent(newJournalEntryLine, "Mongo-History");
            _messagePublisher.Publish(journalEntryLineCreatedEvent);

            response.JournalEntryLine = dto;


            return Ok(response);
        }
    }
}