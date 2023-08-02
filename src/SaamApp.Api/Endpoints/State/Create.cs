using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.State;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.StateEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateStateRequest>.WithActionResult<
        CreateStateResponse>
    {
        private readonly IRepository<Country> _countryRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<State> _repository;

        public Create(
            IRepository<State> repository,
            IRepository<Country> countryRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _countryRepository = countryRepository;
        }

        [HttpPost("api/states")]
        [SwaggerOperation(
            Summary = "Creates a new State",
            Description = "Creates a new State",
            OperationId = "states.create",
            Tags = new[] { "StateEndpoints" })
        ]
        public override async Task<ActionResult<CreateStateResponse>> HandleAsync(
            CreateStateRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateStateResponse(request.CorrelationId());

            //var country = await _countryRepository.GetByIdAsync(request.CountryId);// parent entity

            var newState = new State(
                Guid.NewGuid(),
                request.CountryId,
                request.StateName,
                request.TenantId
            );


            await _repository.AddAsync(newState);

            _logger.LogInformation(
                $"State created  with Id {newState.StateId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<StateDto>(newState);

            var stateCreatedEvent = new StateCreatedEvent(newState, "Mongo-History");
            _messagePublisher.Publish(stateCreatedEvent);

            response.State = dto;


            return Ok(response);
        }
    }
}