using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AccountType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountTypeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAccountTypeRequest>.WithActionResult<
        CreateAccountTypeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AccountType> _repository;

        public Create(
            IRepository<AccountType> repository,
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

        [HttpPost("api/accountTypes")]
        [SwaggerOperation(
            Summary = "Creates a new AccountType",
            Description = "Creates a new AccountType",
            OperationId = "accountTypes.create",
            Tags = new[] { "AccountTypeEndpoints" })
        ]
        public override async Task<ActionResult<CreateAccountTypeResponse>> HandleAsync(
            CreateAccountTypeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAccountTypeResponse(request.CorrelationId());


            var newAccountType = new AccountType(
                Guid.NewGuid(),
                request.AccountTypeCode,
                request.AccountTypeName,
                request.AccountTypeDescription,
                request.TenantId
            );


            await _repository.AddAsync(newAccountType);

            _logger.LogInformation(
                $"AccountType created  with Id {newAccountType.AccountTypeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AccountTypeDto>(newAccountType);

            var accountTypeCreatedEvent = new AccountTypeCreatedEvent(newAccountType, "Mongo-History");
            _messagePublisher.Publish(accountTypeCreatedEvent);

            response.AccountType = dto;


            return Ok(response);
        }
    }
}