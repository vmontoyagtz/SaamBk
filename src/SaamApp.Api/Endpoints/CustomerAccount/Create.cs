using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.CustomerAccount;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerAccountEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCustomerAccountRequest>.WithActionResult<
        CreateCustomerAccountResponse>
    {
        private readonly IRepository<Account> _accountRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerAccount> _repository;

        public Create(
            IRepository<CustomerAccount> repository,
            IRepository<Account> accountRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _accountRepository = accountRepository;
        }

        [HttpPost("api/customerAccounts")]
        [SwaggerOperation(
            Summary = "Creates a new CustomerAccount",
            Description = "Creates a new CustomerAccount",
            OperationId = "customerAccounts.create",
            Tags = new[] { "CustomerAccountEndpoints" })
        ]
        public override async Task<ActionResult<CreateCustomerAccountResponse>> HandleAsync(
            CreateCustomerAccountRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCustomerAccountResponse(request.CorrelationId());

            //var account = await _accountRepository.GetByIdAsync(request.AccountId);// parent entity

            var newCustomerAccount = new CustomerAccount(
                request.AccountId,
                request.CustomerId
            );


            await _repository.AddAsync(newCustomerAccount);

            _logger.LogInformation(
                $"CustomerAccount created  with Id {newCustomerAccount.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CustomerAccountDto>(newCustomerAccount);

            var customerAccountCreatedEvent = new CustomerAccountCreatedEvent(newCustomerAccount, "Mongo-History");
            _messagePublisher.Publish(customerAccountCreatedEvent);

            response.CustomerAccount = dto;


            return Ok(response);
        }
    }
}