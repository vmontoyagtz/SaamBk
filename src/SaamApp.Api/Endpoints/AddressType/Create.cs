using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AddressType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AddressTypeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAddressTypeRequest>.WithActionResult<
        CreateAddressTypeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AddressType> _repository;

        public Create(
            IRepository<AddressType> repository,
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

        [HttpPost("api/addressTypes")]
        [SwaggerOperation(
            Summary = "Creates a new AddressType",
            Description = "Creates a new AddressType",
            OperationId = "addressTypes.create",
            Tags = new[] { "AddressTypeEndpoints" })
        ]
        public override async Task<ActionResult<CreateAddressTypeResponse>> HandleAsync(
            CreateAddressTypeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAddressTypeResponse(request.CorrelationId());


            var newAddressType = new AddressType(
                Guid.NewGuid(),
                request.AddressTypeName,
                request.Description,
                request.TenantId
            );


            await _repository.AddAsync(newAddressType);

            _logger.LogInformation(
                $"AddressType created  with Id {newAddressType.AddressTypeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AddressTypeDto>(newAddressType);

            var addressTypeCreatedEvent = new AddressTypeCreatedEvent(newAddressType, "Mongo-History");
            _messagePublisher.Publish(addressTypeCreatedEvent);

            response.AddressType = dto;


            return Ok(response);
        }
    }
}