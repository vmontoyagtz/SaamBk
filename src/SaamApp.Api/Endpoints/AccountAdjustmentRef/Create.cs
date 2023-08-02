using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountAdjustmentRefEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAccountAdjustmentRefRequest>.WithActionResult<
        CreateAccountAdjustmentRefResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AccountAdjustmentRef> _repository;

        public Create(
            IRepository<AccountAdjustmentRef> repository,
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

        [HttpPost("api/accountAdjustmentRefs")]
        [SwaggerOperation(
            Summary = "Creates a new AccountAdjustmentRef",
            Description = "Creates a new AccountAdjustmentRef",
            OperationId = "accountAdjustmentRefs.create",
            Tags = new[] { "AccountAdjustmentRefEndpoints" })
        ]
        public override async Task<ActionResult<CreateAccountAdjustmentRefResponse>> HandleAsync(
            CreateAccountAdjustmentRefRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAccountAdjustmentRefResponse(request.CorrelationId());


            var newAccountAdjustmentRef = new AccountAdjustmentRef(
                Guid.NewGuid(),
                request.AccountAdjustmentRefName,
                request.AccountAdjustmentRefDescription,
                request.TenantId
            );


            await _repository.AddAsync(newAccountAdjustmentRef);

            _logger.LogInformation(
                $"AccountAdjustmentRef created  with Id {newAccountAdjustmentRef.AccountAdjustmentRefId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AccountAdjustmentRefDto>(newAccountAdjustmentRef);

            var accountAdjustmentRefCreatedEvent =
                new AccountAdjustmentRefCreatedEvent(newAccountAdjustmentRef, "Mongo-History");
            _messagePublisher.Publish(accountAdjustmentRefCreatedEvent);

            response.AccountAdjustmentRef = dto;


            return Ok(response);
        }
    }
}