using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.PhoneNumberType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.PhoneNumberTypeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreatePhoneNumberTypeRequest>.WithActionResult<
        CreatePhoneNumberTypeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PhoneNumberType> _repository;

        public Create(
            IRepository<PhoneNumberType> repository,
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

        [HttpPost("api/phoneNumberTypes")]
        [SwaggerOperation(
            Summary = "Creates a new PhoneNumberType",
            Description = "Creates a new PhoneNumberType",
            OperationId = "phoneNumberTypes.create",
            Tags = new[] { "PhoneNumberTypeEndpoints" })
        ]
        public override async Task<ActionResult<CreatePhoneNumberTypeResponse>> HandleAsync(
            CreatePhoneNumberTypeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreatePhoneNumberTypeResponse(request.CorrelationId());


            var newPhoneNumberType = new PhoneNumberType(
                Guid.NewGuid(),
                request.PhoneNumberTypeName,
                request.Description,
                request.TenantId
            );


            await _repository.AddAsync(newPhoneNumberType);

            _logger.LogInformation(
                $"PhoneNumberType created  with Id {newPhoneNumberType.PhoneNumberTypeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<PhoneNumberTypeDto>(newPhoneNumberType);

            var phoneNumberTypeCreatedEvent = new PhoneNumberTypeCreatedEvent(newPhoneNumberType, "Mongo-History");
            _messagePublisher.Publish(phoneNumberTypeCreatedEvent);

            response.PhoneNumberType = dto;


            return Ok(response);
        }
    }
}