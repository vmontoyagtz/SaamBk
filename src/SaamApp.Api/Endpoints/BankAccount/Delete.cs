using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BankAccount;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BankAccountEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteBankAccountRequest>.WithActionResult<
        DeleteBankAccountResponse>
    {
        private readonly IRepository<AdvisorBank> _advisorBankRepository;
        private readonly IRepository<AdvisorBankTransferInfo> _advisorBankTransferInfoRepository;
        private readonly IRepository<AdvisorPayment> _advisorPaymentRepository;
        private readonly IRepository<BankAccount> _bankAccountReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BankAccount> _repository;

        public Delete(IRepository<BankAccount> BankAccountRepository,
            IRepository<BankAccount> BankAccountReadRepository,
            IRepository<AdvisorBank> advisorBankRepository,
            IRepository<AdvisorBankTransferInfo> advisorBankTransferInfoRepository,
            IRepository<AdvisorPayment> advisorPaymentRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = BankAccountRepository;
            _bankAccountReadRepository = BankAccountReadRepository;
            _advisorBankRepository = advisorBankRepository;
            _advisorBankTransferInfoRepository = advisorBankTransferInfoRepository;
            _advisorPaymentRepository = advisorPaymentRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/bankAccounts/{BankAccountId}")]
        [SwaggerOperation(
            Summary = "Deletes an BankAccount",
            Description = "Deletes an BankAccount",
            OperationId = "bankAccounts.delete",
            Tags = new[] { "BankAccountEndpoints" })
        ]
        public override async Task<ActionResult<DeleteBankAccountResponse>> HandleAsync(
            [FromRoute] DeleteBankAccountRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteBankAccountResponse(request.CorrelationId());

            var bankAccount = await _bankAccountReadRepository.GetByIdAsync(request.BankAccountId);

            if (bankAccount == null)
            {
                return NotFound();
            }

            var advisorBankSpec = new GetAdvisorBankWithBankAccountKeySpec(bankAccount.BankAccountId);
            var advisorBanks = await _advisorBankRepository.ListAsync(advisorBankSpec);
            await _advisorBankRepository.DeleteRangeAsync(advisorBanks);
            var advisorBankTransferInfoSpec =
                new GetAdvisorBankTransferInfoWithBankAccountKeySpec(bankAccount.BankAccountId);
            var advisorBankTransferInfoes =
                await _advisorBankTransferInfoRepository.ListAsync(advisorBankTransferInfoSpec);
            await _advisorBankTransferInfoRepository
                .DeleteRangeAsync(advisorBankTransferInfoes); // you could use soft delete with IsDeleted = true
            var advisorPaymentSpec = new GetAdvisorPaymentWithBankAccountKeySpec(bankAccount.BankAccountId);
            var advisorPayments = await _advisorPaymentRepository.ListAsync(advisorPaymentSpec);
            await _advisorPaymentRepository.DeleteRangeAsync(advisorPayments);

            var bankAccountDeletedEvent = new BankAccountDeletedEvent(bankAccount, "Mongo-History");
            _messagePublisher.Publish(bankAccountDeletedEvent);

            await _repository.DeleteAsync(bankAccount);

            return Ok(response);
        }
    }
}