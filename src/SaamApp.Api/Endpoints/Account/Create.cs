using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Account;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAccountRequest>.WithActionResult<
        CreateAccountResponse>
    {
        private readonly IRepository<AccountStateType> _accountStateTypeRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Account> _repository;

        public Create(
            IRepository<Account> repository,
            IRepository<AccountStateType> accountStateTypeRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _accountStateTypeRepository = accountStateTypeRepository;
        }

        [HttpPost("api/accounts")]
        [SwaggerOperation(
            Summary = "Creates a new Account",
            Description = "Creates a new Account",
            OperationId = "accounts.create",
            Tags = new[] { "AccountEndpoints" })
        ]
        public override async Task<ActionResult<CreateAccountResponse>> HandleAsync(
            CreateAccountRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAccountResponse(request.CorrelationId());

            //var accountStateType = await _accountStateTypeRepository.GetByIdAsync(request.AccountStateTypeId);// parent entity

            var newAccount = new Account(
                Guid.NewGuid(),
                request.AccountStateTypeId,
                request.AccountTypeId,
                request.TaxInformationId,
                request.AccountNumber,
                request.AccountName,
                request.AccountDescription,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newAccount);

            _logger.LogInformation(
                $"Account created  with Id {newAccount.AccountId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AccountDto>(newAccount);

            var accountCreatedEvent = new AccountCreatedEvent(newAccount, "Mongo-History");
            _messagePublisher.Publish(accountCreatedEvent);

            response.Account = dto;


            return Ok(response);
        }
    }
}