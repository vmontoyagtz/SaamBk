using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.TemplateCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateCategoryEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateTemplateCategoryRequest>.WithActionResult<
        CreateTemplateCategoryResponse>
    {
        private readonly IRepository<Comission> _comissionRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TemplateCategory> _repository;

        public Create(
            IRepository<TemplateCategory> repository,
            IRepository<Comission> comissionRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _comissionRepository = comissionRepository;
        }

        [HttpPost("api/templateCategories")]
        [SwaggerOperation(
            Summary = "Creates a new TemplateCategory",
            Description = "Creates a new TemplateCategory",
            OperationId = "templateCategories.create",
            Tags = new[] { "TemplateCategoryEndpoints" })
        ]
        public override async Task<ActionResult<CreateTemplateCategoryResponse>> HandleAsync(
            CreateTemplateCategoryRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateTemplateCategoryResponse(request.CorrelationId());

            //var comission = await _comissionRepository.GetByIdAsync(request.ComissionId);// parent entity

            var newTemplateCategory = new TemplateCategory(
                request.ComissionId,
                request.RegionAreaAdvisorCategoryId,
                request.TemplateId,
                request.TenantId
            );


            await _repository.AddAsync(newTemplateCategory);

            _logger.LogInformation(
                $"TemplateCategory created  with Id {newTemplateCategory.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<TemplateCategoryDto>(newTemplateCategory);

            var templateCategoryCreatedEvent = new TemplateCategoryCreatedEvent(newTemplateCategory, "Mongo-History");
            _messagePublisher.Publish(templateCategoryCreatedEvent);

            response.TemplateCategory = dto;


            return Ok(response);
        }
    }
}