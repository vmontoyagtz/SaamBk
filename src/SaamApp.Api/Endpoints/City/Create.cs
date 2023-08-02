using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.City;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CityEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCityRequest>.WithActionResult<
        CreateCityResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<City> _repository;
        private readonly IRepository<State> _stateRepository;

        public Create(
            IRepository<City> repository,
            IRepository<State> stateRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _stateRepository = stateRepository;
        }

        [HttpPost("api/cities")]
        [SwaggerOperation(
            Summary = "Creates a new City",
            Description = "Creates a new City",
            OperationId = "cities.create",
            Tags = new[] { "CityEndpoints" })
        ]
        public override async Task<ActionResult<CreateCityResponse>> HandleAsync(
            CreateCityRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCityResponse(request.CorrelationId());

            //var state = await _stateRepository.GetByIdAsync(request.StateId);// parent entity

            var newCity = new City(
                Guid.NewGuid(),
                request.StateId,
                request.CityName,
                request.TenantId
            );


            await _repository.AddAsync(newCity);

            _logger.LogInformation(
                $"City created  with Id {newCity.CityId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CityDto>(newCity);

            var cityCreatedEvent = new CityCreatedEvent(newCity, "Mongo-History");
            _messagePublisher.Publish(cityCreatedEvent);

            response.City = dto;


            return Ok(response);
        }
    }
}