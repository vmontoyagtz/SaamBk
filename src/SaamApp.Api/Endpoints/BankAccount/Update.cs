using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BankAccount;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.BankAccountEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateBankAccountRequest>.WithActionResult<
        UpdateBankAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BankAccount> _repository;

        public Update(
            IRepository<BankAccount> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/bankAccounts")]
        [SwaggerOperation(
            Summary = "Updates a BankAccount",
            Description = "Updates a BankAccount",
            OperationId = "bankAccounts.update",
            Tags = new[] { "BankAccountEndpoints" })
        ]
        public override async Task<ActionResult<UpdateBankAccountResponse>> HandleAsync(
            UpdateBankAccountRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateBankAccountResponse(request.CorrelationId());

            var baaanaToUpdate = _mapper.Map<BankAccount>(request);

            var bankAccountToUpdateTest = await _repository.GetByIdAsync(request.BankAccountId);
            if (bankAccountToUpdateTest is null)
            {
                return NotFound();
            }

            baaanaToUpdate.UpdateBankForBankAccount(request.BankId);
            await _repository.UpdateAsync(baaanaToUpdate);

            var bankAccountUpdatedEvent = new BankAccountUpdatedEvent(baaanaToUpdate, "Mongo-History");
            _messagePublisher.Publish(bankAccountUpdatedEvent);

            var dto = _mapper.Map<BankAccountDto>(baaanaToUpdate);
            response.BankAccount = dto;

            return Ok(response);
        }
    }
}