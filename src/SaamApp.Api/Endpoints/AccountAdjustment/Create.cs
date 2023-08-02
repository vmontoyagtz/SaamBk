using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AccountAdjustment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountAdjustmentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAccountAdjustmentRequest>.WithActionResult<
        CreateAccountAdjustmentResponse>
    {
        private readonly IRepository<Account> _accountRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AccountAdjustment> _repository;

        public Create(
            IRepository<AccountAdjustment> repository,
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

        [HttpPost("api/accountAdjustments")]
        [SwaggerOperation(
            Summary = "Creates a new AccountAdjustment",
            Description = "Creates a new AccountAdjustment",
            OperationId = "accountAdjustments.create",
            Tags = new[] { "AccountAdjustmentEndpoints" })
        ]
        public override async Task<ActionResult<CreateAccountAdjustmentResponse>> HandleAsync(
            CreateAccountAdjustmentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAccountAdjustmentResponse(request.CorrelationId());

            //var account = await _accountRepository.GetByIdAsync(request.AccountId);// parent entity

            var newAccountAdjustment = new AccountAdjustment(
                Guid.NewGuid(),
                request.AccountId,
                request.AccountAdjustmentRefId,
                request.AdjustmentReason,
                request.TotalChargeCredited,
                request.TotalTaxCredited,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted
            );


            await _repository.AddAsync(newAccountAdjustment);

            _logger.LogInformation(
                $"AccountAdjustment created  with Id {newAccountAdjustment.AccountAdjustmentId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AccountAdjustmentDto>(newAccountAdjustment);

            var accountAdjustmentCreatedEvent =
                new AccountAdjustmentCreatedEvent(newAccountAdjustment, "Mongo-History");
            _messagePublisher.Publish(accountAdjustmentCreatedEvent);

            response.AccountAdjustment = dto;


            return Ok(response);
        }
    }
}