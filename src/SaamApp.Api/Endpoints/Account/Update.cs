using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Account;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AccountEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAccountRequest>.WithActionResult<UpdateAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Account> _repository;

        public Update(
            IRepository<Account> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/accounts")]
        [SwaggerOperation(
            Summary = "Updates a Account",
            Description = "Updates a Account",
            OperationId = "accounts.update",
            Tags = new[] { "AccountEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAccountResponse>> HandleAsync(UpdateAccountRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateAccountResponse(request.CorrelationId());

            var accToUpdate = _mapper.Map<Account>(request);

            var accountToUpdateTest = await _repository.GetByIdAsync(request.AccountId);
            if (accountToUpdateTest is null)
            {
                return NotFound();
            }

            accToUpdate.UpdateAccountStateTypeForAccount(request.AccountStateTypeId);
            accToUpdate.UpdateAccountTypeForAccount(request.AccountTypeId);
            accToUpdate.UpdateTaxInformationForAccount(request.TaxInformationId);
            await _repository.UpdateAsync(accToUpdate);

            var accountUpdatedEvent = new AccountUpdatedEvent(accToUpdate, "Mongo-History");
            _messagePublisher.Publish(accountUpdatedEvent);

            var dto = _mapper.Map<AccountDto>(accToUpdate);
            response.Account = dto;

            return Ok(response);
        }
    }
}