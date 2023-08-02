using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.FinancialAccountingPeriodEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteFinancialAccountingPeriodRequest>.WithActionResult<
        DeleteFinancialAccountingPeriodResponse>
    {
        private readonly IRepository<FinancialAccountingPeriod> _financialAccountingPeriodReadRepository;
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly IRepository<JournalEntryLine> _journalEntryLineRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<FinancialAccountingPeriod> _repository;

        public Delete(IRepository<FinancialAccountingPeriod> FinancialAccountingPeriodRepository,
            IRepository<FinancialAccountingPeriod> FinancialAccountingPeriodReadRepository,
            IRepository<Invoice> invoiceRepository,
            IRepository<JournalEntryLine> journalEntryLineRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = FinancialAccountingPeriodRepository;
            _financialAccountingPeriodReadRepository = FinancialAccountingPeriodReadRepository;
            _invoiceRepository = invoiceRepository;
            _journalEntryLineRepository = journalEntryLineRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/financialAccountingPeriods/{FinancialAccountingPeriodId}")]
        [SwaggerOperation(
            Summary = "Deletes an FinancialAccountingPeriod",
            Description = "Deletes an FinancialAccountingPeriod",
            OperationId = "financialAccountingPeriods.delete",
            Tags = new[] { "FinancialAccountingPeriodEndpoints" })
        ]
        public override async Task<ActionResult<DeleteFinancialAccountingPeriodResponse>> HandleAsync(
            [FromRoute] DeleteFinancialAccountingPeriodRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteFinancialAccountingPeriodResponse(request.CorrelationId());

            var financialAccountingPeriod =
                await _financialAccountingPeriodReadRepository.GetByIdAsync(request.FinancialAccountingPeriodId);

            if (financialAccountingPeriod == null)
            {
                return NotFound();
            }

            var invoiceSpec =
                new GetInvoiceWithFinancialAccountingPeriodKeySpec(
                    financialAccountingPeriod.FinancialAccountingPeriodId);
            var invoices = await _invoiceRepository.ListAsync(invoiceSpec);
            await _invoiceRepository.DeleteRangeAsync(invoices); // you could use soft delete with IsDeleted = true
            var journalEntryLineSpec =
                new GetJournalEntryLineWithFinancialAccountingPeriodKeySpec(financialAccountingPeriod
                    .FinancialAccountingPeriodId);
            var journalEntryLines = await _journalEntryLineRepository.ListAsync(journalEntryLineSpec);
            await _journalEntryLineRepository
                .DeleteRangeAsync(journalEntryLines); // you could use soft delete with IsDeleted = true

            var financialAccountingPeriodDeletedEvent =
                new FinancialAccountingPeriodDeletedEvent(financialAccountingPeriod, "Mongo-History");
            _messagePublisher.Publish(financialAccountingPeriodDeletedEvent);

            await _repository.DeleteAsync(financialAccountingPeriod);

            return Ok(response);
        }
    }
}