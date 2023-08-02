using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.EmailAddressType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmailAddressTypeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateEmailAddressTypeRequest>.WithActionResult<
        CreateEmailAddressTypeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmailAddressType> _repository;

        public Create(
            IRepository<EmailAddressType> repository,
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

        [HttpPost("api/emailAddressTypes")]
        [SwaggerOperation(
            Summary = "Creates a new EmailAddressType",
            Description = "Creates a new EmailAddressType",
            OperationId = "emailAddressTypes.create",
            Tags = new[] { "EmailAddressTypeEndpoints" })
        ]
        public override async Task<ActionResult<CreateEmailAddressTypeResponse>> HandleAsync(
            CreateEmailAddressTypeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateEmailAddressTypeResponse(request.CorrelationId());


            var newEmailAddressType = new EmailAddressType(
                Guid.NewGuid(),
                request.EmailAddressTypeName,
                request.Description,
                request.TenantId
            );


            await _repository.AddAsync(newEmailAddressType);

            _logger.LogInformation(
                $"EmailAddressType created  with Id {newEmailAddressType.EmailAddressTypeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<EmailAddressTypeDto>(newEmailAddressType);

            var emailAddressTypeCreatedEvent = new EmailAddressTypeCreatedEvent(newEmailAddressType, "Mongo-History");
            _messagePublisher.Publish(emailAddressTypeCreatedEvent);

            response.EmailAddressType = dto;


            return Ok(response);
        }
    }
}