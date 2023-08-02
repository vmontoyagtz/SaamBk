using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Account;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAccountRequest>.WithActionResult<
        DeleteAccountResponse>
    {
        private readonly IRepository<AccountAdjustment> _accountAdjustmentRepository;
        private readonly IRepository<Account> _accountReadRepository;
        private readonly IRepository<CustomerAccount> _customerAccountRepository;
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly IRepository<JournalEntryLine> _journalEntryLineRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Account> _repository;

        public Delete(IRepository<Account> AccountRepository, IRepository<Account> AccountReadRepository,
            IRepository<AccountAdjustment> accountAdjustmentRepository,
            IRepository<CustomerAccount> customerAccountRepository,
            IRepository<Invoice> invoiceRepository,
            IRepository<JournalEntryLine> journalEntryLineRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AccountRepository;
            _accountReadRepository = AccountReadRepository;
            _accountAdjustmentRepository = accountAdjustmentRepository;
            _customerAccountRepository = customerAccountRepository;
            _invoiceRepository = invoiceRepository;
            _journalEntryLineRepository = journalEntryLineRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/accounts/{AccountId}")]
        [SwaggerOperation(
            Summary = "Deletes an Account",
            Description = "Deletes an Account",
            OperationId = "accounts.delete",
            Tags = new[] { "AccountEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAccountResponse>> HandleAsync(
            [FromRoute] DeleteAccountRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAccountResponse(request.CorrelationId());

            var account = await _accountReadRepository.GetByIdAsync(request.AccountId);

            if (account == null)
            {
                return NotFound();
            }

            var accountAdjustmentSpec = new GetAccountAdjustmentWithAccountKeySpec(account.AccountId);
            var accountAdjustments = await _accountAdjustmentRepository.ListAsync(accountAdjustmentSpec);
            await _accountAdjustmentRepository
                .DeleteRangeAsync(accountAdjustments); // you could use soft delete with IsDeleted = true
            var customerAccountSpec = new GetCustomerAccountWithAccountKeySpec(account.AccountId);
            var customerAccounts = await _customerAccountRepository.ListAsync(customerAccountSpec);
            await _customerAccountRepository.DeleteRangeAsync(customerAccounts);
            var invoiceSpec = new GetInvoiceWithAccountKeySpec(account.AccountId);
            var invoices = await _invoiceRepository.ListAsync(invoiceSpec);
            await _invoiceRepository.DeleteRangeAsync(invoices); // you could use soft delete with IsDeleted = true
            var journalEntryLineSpec = new GetJournalEntryLineWithAccountKeySpec(account.AccountId);
            var journalEntryLines = await _journalEntryLineRepository.ListAsync(journalEntryLineSpec);
            await _journalEntryLineRepository
                .DeleteRangeAsync(journalEntryLines); // you could use soft delete with IsDeleted = true

            var accountDeletedEvent = new AccountDeletedEvent(account, "Mongo-History");
            _messagePublisher.Publish(accountDeletedEvent);

            await _repository.DeleteAsync(account);

            return Ok(response);
        }
    }
}