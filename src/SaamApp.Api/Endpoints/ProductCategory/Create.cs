using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.ProductCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ProductCategoryEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateProductCategoryRequest>.WithActionResult<
        CreateProductCategoryResponse>
    {
        private readonly IRepository<Comission> _comissionRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<ProductCategory> _repository;

        public Create(
            IRepository<ProductCategory> repository,
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

        [HttpPost("api/productCategories")]
        [SwaggerOperation(
            Summary = "Creates a new ProductCategory",
            Description = "Creates a new ProductCategory",
            OperationId = "productCategories.create",
            Tags = new[] { "ProductCategoryEndpoints" })
        ]
        public override async Task<ActionResult<CreateProductCategoryResponse>> HandleAsync(
            CreateProductCategoryRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateProductCategoryResponse(request.CorrelationId());

            //var comission = await _comissionRepository.GetByIdAsync(request.ComissionId);// parent entity

            var newProductCategory = new ProductCategory(
                request.ComissionId,
                request.ProductId,
                request.RegionAreaAdvisorCategoryId,
                request.TenantId
            );


            await _repository.AddAsync(newProductCategory);

            _logger.LogInformation(
                $"ProductCategory created  with Id {newProductCategory.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<ProductCategoryDto>(newProductCategory);

            var productCategoryCreatedEvent = new ProductCategoryCreatedEvent(newProductCategory, "Mongo-History");
            _messagePublisher.Publish(productCategoryCreatedEvent);

            response.ProductCategory = dto;


            return Ok(response);
        }
    }
}