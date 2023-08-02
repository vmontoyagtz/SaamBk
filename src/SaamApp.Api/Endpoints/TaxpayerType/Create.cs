using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.TaxpayerType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TaxpayerTypeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateTaxpayerTypeRequest>.WithActionResult<
        CreateTaxpayerTypeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TaxpayerType> _repository;

        public Create(
            IRepository<TaxpayerType> repository,
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

        [HttpPost("api/taxpayerTypes")]
        [SwaggerOperation(
            Summary = "Creates a new TaxpayerType",
            Description = "Creates a new TaxpayerType",
            OperationId = "taxpayerTypes.create",
            Tags = new[] { "TaxpayerTypeEndpoints" })
        ]
        public override async Task<ActionResult<CreateTaxpayerTypeResponse>> HandleAsync(
            CreateTaxpayerTypeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateTaxpayerTypeResponse(request.CorrelationId());


            var newTaxpayerType = new TaxpayerType(
                Guid.NewGuid(),
                request.TaxpayerTypeName,
                request.TenantId
            );


            await _repository.AddAsync(newTaxpayerType);

            _logger.LogInformation(
                $"TaxpayerType created  with Id {newTaxpayerType.TaxpayerTypeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<TaxpayerTypeDto>(newTaxpayerType);

            var taxpayerTypeCreatedEvent = new TaxpayerTypeCreatedEvent(newTaxpayerType, "Mongo-History");
            _messagePublisher.Publish(taxpayerTypeCreatedEvent);

            response.TaxpayerType = dto;


            return Ok(response);
        }
    }
}