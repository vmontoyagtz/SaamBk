using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.PhoneNumber;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PhoneNumberEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreatePhoneNumberRequest>.WithActionResult<
        CreatePhoneNumberResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PhoneNumber> _repository;

        public Create(
            IRepository<PhoneNumber> repository,
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

        [HttpPost("api/phoneNumbers")]
        [SwaggerOperation(
            Summary = "Creates a new PhoneNumber",
            Description = "Creates a new PhoneNumber",
            OperationId = "phoneNumbers.create",
            Tags = new[] { "PhoneNumberEndpoints" })
        ]
        public override async Task<ActionResult<CreatePhoneNumberResponse>> HandleAsync(
            CreatePhoneNumberRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreatePhoneNumberResponse(request.CorrelationId());


            var newPhoneNumber = new PhoneNumber(
                Guid.NewGuid(),
                request.PhoneNumberString
            );


            await _repository.AddAsync(newPhoneNumber);

            _logger.LogInformation(
                $"PhoneNumber created  with Id {newPhoneNumber.PhoneNumberId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<PhoneNumberDto>(newPhoneNumber);

            var phoneNumberCreatedEvent = new PhoneNumberCreatedEvent(newPhoneNumber, "Mongo-History");
            _messagePublisher.Publish(phoneNumberCreatedEvent);

            response.PhoneNumber = dto;


            return Ok(response);
        }
    }
}