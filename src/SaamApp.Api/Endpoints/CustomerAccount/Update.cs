using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerAccount;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CustomerAccountEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCustomerAccountRequest>.WithActionResult<
        UpdateCustomerAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerAccount> _repository;

        public Update(
            IRepository<CustomerAccount> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/customerAccounts")]
        [SwaggerOperation(
            Summary = "Updates a CustomerAccount",
            Description = "Updates a CustomerAccount",
            OperationId = "customerAccounts.update",
            Tags = new[] { "CustomerAccountEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCustomerAccountResponse>> HandleAsync(
            UpdateCustomerAccountRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCustomerAccountResponse(request.CorrelationId());

            var cauasaToUpdate = _mapper.Map<CustomerAccount>(request);

            var customerAccountToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (customerAccountToUpdateTest is null)
            {
                return NotFound();
            }

            cauasaToUpdate.UpdateAccountForCustomerAccount(request.AccountId);
            cauasaToUpdate.UpdateCustomerForCustomerAccount(request.CustomerId);
            await _repository.UpdateAsync(cauasaToUpdate);

            var customerAccountUpdatedEvent = new CustomerAccountUpdatedEvent(cauasaToUpdate, "Mongo-History");
            _messagePublisher.Publish(customerAccountUpdatedEvent);

            var dto = _mapper.Map<CustomerAccountDto>(cauasaToUpdate);
            response.CustomerAccount = dto;

            return Ok(response);
        }
    }
}