using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.BusinessUnit;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateBusinessUnitRequest>.WithActionResult<
        CreateBusinessUnitResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnit> _repository;

        public Create(
            IRepository<BusinessUnit> repository,
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

        [HttpPost("api/businessUnits")]
        [SwaggerOperation(
            Summary = "Creates a new BusinessUnit",
            Description = "Creates a new BusinessUnit",
            OperationId = "businessUnits.create",
            Tags = new[] { "BusinessUnitEndpoints" })
        ]
        public override async Task<ActionResult<CreateBusinessUnitResponse>> HandleAsync(
            CreateBusinessUnitRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateBusinessUnitResponse(request.CorrelationId());


            var newBusinessUnit = new BusinessUnit(
                Guid.NewGuid(),
                request.BusinessUnitName,
                request.BusinessAddressId,
                request.BusinessPhoneNumberId,
                request.BusinessEmailAddressId,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newBusinessUnit);

            _logger.LogInformation(
                $"BusinessUnit created  with Id {newBusinessUnit.BusinessUnitId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<BusinessUnitDto>(newBusinessUnit);

            var businessUnitCreatedEvent = new BusinessUnitCreatedEvent(newBusinessUnit, "Mongo-History");
            _messagePublisher.Publish(businessUnitCreatedEvent);

            response.BusinessUnit = dto;


            return Ok(response);
        }
    }
}