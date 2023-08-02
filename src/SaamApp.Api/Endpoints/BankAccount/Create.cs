using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.BankAccount;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BankAccountEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateBankAccountRequest>.WithActionResult<
        CreateBankAccountResponse>
    {
        private readonly IRepository<Bank> _bankRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BankAccount> _repository;

        public Create(
            IRepository<BankAccount> repository,
            IRepository<Bank> bankRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _bankRepository = bankRepository;
        }

        [HttpPost("api/bankAccounts")]
        [SwaggerOperation(
            Summary = "Creates a new BankAccount",
            Description = "Creates a new BankAccount",
            OperationId = "bankAccounts.create",
            Tags = new[] { "BankAccountEndpoints" })
        ]
        public override async Task<ActionResult<CreateBankAccountResponse>> HandleAsync(
            CreateBankAccountRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateBankAccountResponse(request.CorrelationId());

            //var bank = await _bankRepository.GetByIdAsync(request.BankId);// parent entity

            var newBankAccount = new BankAccount(
                Guid.NewGuid(),
                request.BankId,
                request.BankAccountName,
                request.BankAccountNumber,
                request.BankAccountNotificationPhoneNumber,
                request.BankAccountNotificationEmailAddress,
                request.Description,
                request.IsDefault,
                request.TenantId
            );


            await _repository.AddAsync(newBankAccount);

            _logger.LogInformation(
                $"BankAccount created  with Id {newBankAccount.BankAccountId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<BankAccountDto>(newBankAccount);

            var bankAccountCreatedEvent = new BankAccountCreatedEvent(newBankAccount, "Mongo-History");
            _messagePublisher.Publish(bankAccountCreatedEvent);

            response.BankAccount = dto;


            return Ok(response);
        }
    }
}