using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Address;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AddressEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAddressRequest>.WithActionResult<
        CreateAddressResponse>
    {
        private readonly IRepository<City> _cityRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Address> _repository;

        public Create(
            IRepository<Address> repository,
            IRepository<City> cityRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _cityRepository = cityRepository;
        }

        [HttpPost("api/addresses")]
        [SwaggerOperation(
            Summary = "Creates a new Address",
            Description = "Creates a new Address",
            OperationId = "addresses.create",
            Tags = new[] { "AddressEndpoints" })
        ]
        public override async Task<ActionResult<CreateAddressResponse>> HandleAsync(
            CreateAddressRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAddressResponse(request.CorrelationId());

            //var city = await _cityRepository.GetByIdAsync(request.CityId);// parent entity

            var newAddress = new Address(
                Guid.NewGuid(),
                request.CityId,
                request.CountryId,
                request.RegionId,
                request.StateId,
                request.AddressStr,
                request.ZipCode,
                request.TenantId
            );


            await _repository.AddAsync(newAddress);

            _logger.LogInformation(
                $"Address created  with Id {newAddress.AddressId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AddressDto>(newAddress);

            var addressCreatedEvent = new AddressCreatedEvent(newAddress, "Mongo-History");
            _messagePublisher.Publish(addressCreatedEvent);

            response.Address = dto;


            return Ok(response);
        }
    }
}