using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Country;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CountryEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCountryRequest>.WithActionResult<
        CreateCountryResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Region> _regionRepository;
        private readonly IRepository<Country> _repository;

        public Create(
            IRepository<Country> repository,
            IRepository<Region> regionRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _regionRepository = regionRepository;
        }

        [HttpPost("api/countries")]
        [SwaggerOperation(
            Summary = "Creates a new Country",
            Description = "Creates a new Country",
            OperationId = "countries.create",
            Tags = new[] { "CountryEndpoints" })
        ]
        public override async Task<ActionResult<CreateCountryResponse>> HandleAsync(
            CreateCountryRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCountryResponse(request.CorrelationId());

            //var region = await _regionRepository.GetByIdAsync(request.RegionId);// parent entity

            var newCountry = new Country(
                Guid.NewGuid(),
                request.RegionId,
                request.CountryName,
                request.CountryCode,
                request.TenantId
            );


            await _repository.AddAsync(newCountry);

            _logger.LogInformation(
                $"Country created  with Id {newCountry.CountryId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CountryDto>(newCountry);

            var countryCreatedEvent = new CountryCreatedEvent(newCountry, "Mongo-History");
            _messagePublisher.Publish(countryCreatedEvent);

            response.Country = dto;


            return Ok(response);
        }
    }
}