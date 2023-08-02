using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerAccount;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerAccountEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCustomerAccountRequest>.WithActionResult<
        DeleteCustomerAccountResponse>
    {
        private readonly IRepository<CustomerAccount> _customerAccountReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerAccount> _repository;

        public Delete(IRepository<CustomerAccount> CustomerAccountRepository,
            IRepository<CustomerAccount> CustomerAccountReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CustomerAccountRepository;
            _customerAccountReadRepository = CustomerAccountReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/customerAccounts/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an CustomerAccount",
            Description = "Deletes an CustomerAccount",
            OperationId = "customerAccounts.delete",
            Tags = new[] { "CustomerAccountEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCustomerAccountResponse>> HandleAsync(
            [FromRoute] DeleteCustomerAccountRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCustomerAccountResponse(request.CorrelationId());

            var customerAccount = await _customerAccountReadRepository.GetByIdAsync(request.RowId);

            if (customerAccount == null)
            {
                return NotFound();
            }


            var customerAccountDeletedEvent = new CustomerAccountDeletedEvent(customerAccount, "Mongo-History");
            _messagePublisher.Publish(customerAccountDeletedEvent);

            await _repository.DeleteAsync(customerAccount);

            return Ok(response);
        }
    }
}