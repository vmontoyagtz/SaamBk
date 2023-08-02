using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Region;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.RegionEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateRegionRequest>.WithActionResult<
        CreateRegionResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Region> _repository;

        public Create(
            IRepository<Region> repository,
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

        [HttpPost("api/regions")]
        [SwaggerOperation(
            Summary = "Creates a new Region",
            Description = "Creates a new Region",
            OperationId = "regions.create",
            Tags = new[] { "RegionEndpoints" })
        ]
        public override async Task<ActionResult<CreateRegionResponse>> HandleAsync(
            CreateRegionRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateRegionResponse(request.CorrelationId());


            var newRegion = new Region(
                Guid.NewGuid(),
                request.RegionName,
                request.RegionCode,
                request.TenantId
            );


            await _repository.AddAsync(newRegion);

            _logger.LogInformation(
                $"Region created  with Id {newRegion.RegionId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<RegionDto>(newRegion);

            var regionCreatedEvent = new RegionCreatedEvent(newRegion, "Mongo-History");
            _messagePublisher.Publish(regionCreatedEvent);

            response.Region = dto;


            return Ok(response);
        }
    }
}