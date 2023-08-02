using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountTypeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAccountTypeRequest>.WithActionResult<
        DeleteAccountTypeResponse>
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<AccountType> _accountTypeReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AccountType> _repository;

        public Delete(IRepository<AccountType> AccountTypeRepository,
            IRepository<AccountType> AccountTypeReadRepository,
            IRepository<Account> accountRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AccountTypeRepository;
            _accountTypeReadRepository = AccountTypeReadRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/accountTypes/{AccountTypeId}")]
        [SwaggerOperation(
            Summary = "Deletes an AccountType",
            Description = "Deletes an AccountType",
            OperationId = "accountTypes.delete",
            Tags = new[] { "AccountTypeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAccountTypeResponse>> HandleAsync(
            [FromRoute] DeleteAccountTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAccountTypeResponse(request.CorrelationId());

            var accountType = await _accountTypeReadRepository.GetByIdAsync(request.AccountTypeId);

            if (accountType == null)
            {
                return NotFound();
            }

            var accountSpec = new GetAccountWithAccountTypeKeySpec(accountType.AccountTypeId);
            var accounts = await _accountRepository.ListAsync(accountSpec);
            await _accountRepository.DeleteRangeAsync(accounts); // you could use soft delete with IsDeleted = true

            var accountTypeDeletedEvent = new AccountTypeDeletedEvent(accountType, "Mongo-History");
            _messagePublisher.Publish(accountTypeDeletedEvent);

            await _repository.DeleteAsync(accountType);

            return Ok(response);
        }
    }
}