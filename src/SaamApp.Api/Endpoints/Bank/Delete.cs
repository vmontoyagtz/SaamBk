using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Bank;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BankEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteBankRequest>.WithActionResult<
        DeleteBankResponse>
    {
        private readonly IRepository<BankAccount> _bankAccountRepository;
        private readonly IRepository<Bank> _bankReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Bank> _repository;

        public Delete(IRepository<Bank> BankRepository, IRepository<Bank> BankReadRepository,
            IRepository<BankAccount> bankAccountRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = BankRepository;
            _bankReadRepository = BankReadRepository;
            _bankAccountRepository = bankAccountRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/banks/{BankId}")]
        [SwaggerOperation(
            Summary = "Deletes an Bank",
            Description = "Deletes an Bank",
            OperationId = "banks.delete",
            Tags = new[] { "BankEndpoints" })
        ]
        public override async Task<ActionResult<DeleteBankResponse>> HandleAsync(
            [FromRoute] DeleteBankRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteBankResponse(request.CorrelationId());

            var bank = await _bankReadRepository.GetByIdAsync(request.BankId);

            if (bank == null)
            {
                return NotFound();
            }

            var bankAccountSpec = new GetBankAccountWithBankKeySpec(bank.BankId);
            var bankAccounts = await _bankAccountRepository.ListAsync(bankAccountSpec);
            await _bankAccountRepository
                .DeleteRangeAsync(bankAccounts); // you could use soft delete with IsDeleted = true

            var bankDeletedEvent = new BankDeletedEvent(bank, "Mongo-History");
            _messagePublisher.Publish(bankDeletedEvent);

            await _repository.DeleteAsync(bank);

            return Ok(response);
        }
    }
}