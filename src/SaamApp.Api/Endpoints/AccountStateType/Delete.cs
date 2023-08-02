using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountStateType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountStateTypeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAccountStateTypeRequest>.WithActionResult<
        DeleteAccountStateTypeResponse>
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<AccountStateType> _accountStateTypeReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AccountStateType> _repository;

        public Delete(IRepository<AccountStateType> AccountStateTypeRepository,
            IRepository<AccountStateType> AccountStateTypeReadRepository,
            IRepository<Account> accountRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AccountStateTypeRepository;
            _accountStateTypeReadRepository = AccountStateTypeReadRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/accountStateTypes/{AccountStateTypeId}")]
        [SwaggerOperation(
            Summary = "Deletes an AccountStateType",
            Description = "Deletes an AccountStateType",
            OperationId = "accountStateTypes.delete",
            Tags = new[] { "AccountStateTypeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAccountStateTypeResponse>> HandleAsync(
            [FromRoute] DeleteAccountStateTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAccountStateTypeResponse(request.CorrelationId());

            var accountStateType = await _accountStateTypeReadRepository.GetByIdAsync(request.AccountStateTypeId);

            if (accountStateType == null)
            {
                return NotFound();
            }

            var accountSpec = new GetAccountWithAccountStateTypeKeySpec(accountStateType.AccountStateTypeId);
            var accounts = await _accountRepository.ListAsync(accountSpec);
            await _accountRepository.DeleteRangeAsync(accounts); // you could use soft delete with IsDeleted = true

            var accountStateTypeDeletedEvent = new AccountStateTypeDeletedEvent(accountStateType, "Mongo-History");
            _messagePublisher.Publish(accountStateTypeDeletedEvent);

            await _repository.DeleteAsync(accountStateType);

            return Ok(response);
        }
    }
}