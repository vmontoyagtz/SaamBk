using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Template;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateTemplateRequest>.WithActionResult<
        CreateTemplateResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Template> _repository;
        private readonly IRepository<TemplateType> _templateTypeRepository;

        public Create(
            IRepository<Template> repository,
            IRepository<TemplateType> templateTypeRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _templateTypeRepository = templateTypeRepository;
        }

        [HttpPost("api/templates")]
        [SwaggerOperation(
            Summary = "Creates a new Template",
            Description = "Creates a new Template",
            OperationId = "templates.create",
            Tags = new[] { "TemplateEndpoints" })
        ]
        public override async Task<ActionResult<CreateTemplateResponse>> HandleAsync(
            CreateTemplateRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateTemplateResponse(request.CorrelationId());

            //var templateType = await _templateTypeRepository.GetByIdAsync(request.TemplateTypeId);// parent entity

            var newTemplate = new Template(
                Guid.NewGuid(),
                request.TemplateTypeId,
                request.TemplateName,
                request.TemplateDescription,
                request.TemplateUnitPrice,
                request.TemplateIsActive,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newTemplate);

            _logger.LogInformation(
                $"Template created  with Id {newTemplate.TemplateId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<TemplateDto>(newTemplate);

            var templateCreatedEvent = new TemplateCreatedEvent(newTemplate, "Mongo-History");
            _messagePublisher.Publish(templateCreatedEvent);

            response.Template = dto;


            return Ok(response);
        }
    }
}