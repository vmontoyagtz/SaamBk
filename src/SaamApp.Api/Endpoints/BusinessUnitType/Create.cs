using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.BusinessUnitType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitTypeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateBusinessUnitTypeRequest>.WithActionResult<
        CreateBusinessUnitTypeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitType> _repository;

        public Create(
            IRepository<BusinessUnitType> repository,
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

        [HttpPost("api/businessUnitTypes")]
        [SwaggerOperation(
            Summary = "Creates a new BusinessUnitType",
            Description = "Creates a new BusinessUnitType",
            OperationId = "businessUnitTypes.create",
            Tags = new[] { "BusinessUnitTypeEndpoints" })
        ]
        public override async Task<ActionResult<CreateBusinessUnitTypeResponse>> HandleAsync(
            CreateBusinessUnitTypeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateBusinessUnitTypeResponse(request.CorrelationId());


            var newBusinessUnitType = new BusinessUnitType(
                Guid.NewGuid(),
                request.BusinessUnitTypeName,
                request.BusinessUnitTypeDescription
            );


            await _repository.AddAsync(newBusinessUnitType);

            _logger.LogInformation(
                $"BusinessUnitType created  with Id {newBusinessUnitType.BusinessUnitTypeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<BusinessUnitTypeDto>(newBusinessUnitType);

            var businessUnitTypeCreatedEvent = new BusinessUnitTypeCreatedEvent(newBusinessUnitType, "Mongo-History");
            _messagePublisher.Publish(businessUnitTypeCreatedEvent);

            response.BusinessUnitType = dto;


            return Ok(response);
        }
    }
}