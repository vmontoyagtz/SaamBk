using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Area;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AreaEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAreaRequest>.WithActionResult<
        CreateAreaResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Area> _repository;

        public Create(
            IRepository<Area> repository,
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

        [HttpPost("api/areas")]
        [SwaggerOperation(
            Summary = "Creates a new Area",
            Description = "Creates a new Area",
            OperationId = "areas.create",
            Tags = new[] { "AreaEndpoints" })
        ]
        public override async Task<ActionResult<CreateAreaResponse>> HandleAsync(
            CreateAreaRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAreaResponse(request.CorrelationId());


            var newArea = new Area(
                Guid.NewGuid(),
                request.AreaName,
                request.AreaDescription,
                request.AreaColor,
                request.AreaImage,
                request.AreaStage,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newArea);

            _logger.LogInformation(
                $"Area created  with Id {newArea.AreaId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AreaDto>(newArea);

            var areaCreatedEvent = new AreaCreatedEvent(newArea, "Mongo-History");
            _messagePublisher.Publish(areaCreatedEvent);

            response.Area = dto;


            return Ok(response);
        }
    }
}