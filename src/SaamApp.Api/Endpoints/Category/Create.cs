using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Category;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CategoryEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCategoryRequest>.WithActionResult<
        CreateCategoryResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Category> _repository;

        public Create(
            IRepository<Category> repository,
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

        [HttpPost("api/categories")]
        [SwaggerOperation(
            Summary = "Creates a new Category",
            Description = "Creates a new Category",
            OperationId = "categories.create",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult<CreateCategoryResponse>> HandleAsync(
            CreateCategoryRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCategoryResponse(request.CorrelationId());


            var newCategory = new Category(
                Guid.NewGuid(),
                request.CategoryName,
                request.CategoryDescription,
                request.CategoryImage,
                request.CategoryStage,
                request.TenantId
            );


            await _repository.AddAsync(newCategory);

            _logger.LogInformation(
                $"Category created  with Id {newCategory.CategoryId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CategoryDto>(newCategory);

            var categoryCreatedEvent = new CategoryCreatedEvent(newCategory, "Mongo-History");
            _messagePublisher.Publish(categoryCreatedEvent);

            response.Category = dto;


            return Ok(response);
        }
    }
}