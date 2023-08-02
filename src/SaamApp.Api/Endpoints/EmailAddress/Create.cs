using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.EmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.EmailAddressEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateEmailAddressRequest>.WithActionResult<
        CreateEmailAddressResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<EmailAddress> _repository;

        public Create(
            IRepository<EmailAddress> repository,
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

        [HttpPost("api/emailAddresses")]
        [SwaggerOperation(
            Summary = "Creates a new EmailAddress",
            Description = "Creates a new EmailAddress",
            OperationId = "emailAddresses.create",
            Tags = new[] { "EmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<CreateEmailAddressResponse>> HandleAsync(
            CreateEmailAddressRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateEmailAddressResponse(request.CorrelationId());


            var newEmailAddress = new EmailAddress(
                Guid.NewGuid(),
                request.EmailAddressString
            );


            await _repository.AddAsync(newEmailAddress);

            _logger.LogInformation(
                $"EmailAddress created  with Id {newEmailAddress.EmailAddressId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<EmailAddressDto>(newEmailAddress);

            var emailAddressCreatedEvent = new EmailAddressCreatedEvent(newEmailAddress, "Mongo-History");
            _messagePublisher.Publish(emailAddressCreatedEvent);

            response.EmailAddress = dto;


            return Ok(response);
        }
    }
}