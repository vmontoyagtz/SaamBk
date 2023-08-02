using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AccountStateType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountStateTypeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAccountStateTypeRequest>.WithActionResult<
        CreateAccountStateTypeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AccountStateType> _repository;

        public Create(
            IRepository<AccountStateType> repository,
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

        [HttpPost("api/accountStateTypes")]
        [SwaggerOperation(
            Summary = "Creates a new AccountStateType",
            Description = "Creates a new AccountStateType",
            OperationId = "accountStateTypes.create",
            Tags = new[] { "AccountStateTypeEndpoints" })
        ]
        public override async Task<ActionResult<CreateAccountStateTypeResponse>> HandleAsync(
            CreateAccountStateTypeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAccountStateTypeResponse(request.CorrelationId());


            var newAccountStateType = new AccountStateType(
                Guid.NewGuid(),
                request.AccountStateTypeCode,
                request.AccountStateTypeName,
                request.AccountStateTypeDescription,
                request.TenantId
            );


            await _repository.AddAsync(newAccountStateType);

            _logger.LogInformation(
                $"AccountStateType created  with Id {newAccountStateType.AccountStateTypeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AccountStateTypeDto>(newAccountStateType);

            var accountStateTypeCreatedEvent = new AccountStateTypeCreatedEvent(newAccountStateType, "Mongo-History");
            _messagePublisher.Publish(accountStateTypeCreatedEvent);

            response.AccountStateType = dto;


            return Ok(response);
        }
    }
}