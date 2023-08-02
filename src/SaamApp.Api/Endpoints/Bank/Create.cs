using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Bank;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BankEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateBankRequest>.WithActionResult<
        CreateBankResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Bank> _repository;

        public Create(
            IRepository<Bank> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/banks")]
        [SwaggerOperation(
            Summary = "Creates a new Bank",
            Description = "Creates a new Bank",
            OperationId = "banks.create",
            Tags = new[] { "BankEndpoints" })
        ]
        public override async Task<ActionResult<CreateBankResponse>> HandleAsync(
            CreateBankRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateBankResponse(request.CorrelationId());


            var newBank = new Bank(
                Guid.NewGuid(),
                request.BankName,
                request.BankSwiftCodeInfo,
                request.BankAddress,
                request.BankPhoneNumber,
                request.BankEmailAddress,
                request.BankNotes,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newBank);

            _logger.LogInformation(
                $"Bank created  with Id {newBank.BankId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<BankDto>(newBank);

            var bankCreatedEvent = new BankCreatedEvent(newBank, "Mongo-History");
            _messagePublisher.Publish(bankCreatedEvent);

            response.Bank = dto;


            return Ok(response);
        }
    }
}