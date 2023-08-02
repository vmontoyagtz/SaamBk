using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.TemplateType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateTypeEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateTemplateTypeRequest>.WithActionResult<
        CreateTemplateTypeResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TemplateType> _repository;

        public Create(
            IRepository<TemplateType> repository,
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

        [HttpPost("api/templateTypes")]
        [SwaggerOperation(
            Summary = "Creates a new TemplateType",
            Description = "Creates a new TemplateType",
            OperationId = "templateTypes.create",
            Tags = new[] { "TemplateTypeEndpoints" })
        ]
        public override async Task<ActionResult<CreateTemplateTypeResponse>> HandleAsync(
            CreateTemplateTypeRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateTemplateTypeResponse(request.CorrelationId());


            var newTemplateType = new TemplateType(
                Guid.NewGuid(),
                request.TemplateTypeName,
                request.TemplateTypeDescription,
                request.TenantId
            );


            await _repository.AddAsync(newTemplateType);

            _logger.LogInformation(
                $"TemplateType created  with Id {newTemplateType.TemplateTypeId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<TemplateTypeDto>(newTemplateType);

            var templateTypeCreatedEvent = new TemplateTypeCreatedEvent(newTemplateType, "Mongo-History");
            _messagePublisher.Publish(templateTypeCreatedEvent);

            response.TemplateType = dto;


            return Ok(response);
        }
    }
}