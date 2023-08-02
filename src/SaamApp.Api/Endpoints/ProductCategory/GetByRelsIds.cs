using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.ProductCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ProductCategoryEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsProductCategoryRequest>.WithActionResult<
        GetByIdProductCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ProductCategory> _repository;

        public GetByRelsIds(
            IRepository<ProductCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/productCategories/{RegionAreaAdvisorCategoryId}/{ComissionId}/{ProductId}/{TenantId}")]
        [SwaggerOperation(
            Summary = "Get a ProductCategory by rel Ids",
            Description = "Gets a ProductCategory by rel Ids",
            OperationId = "productCategories.GetByRelsIds",
            Tags = new[] { "ProductCategoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdProductCategoryResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsProductCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdProductCategoryResponse(request.CorrelationId());

            var spec = new ProductCategoryByRelIdsSpec(request.RegionAreaAdvisorCategoryId, request.ComissionId,
                request.ProductId, request.TenantId);

            var productCategory = await _repository.FirstOrDefaultAsync(spec);


            if (productCategory is null)
            {
                return NotFound();
            }

            response.ProductCategory = _mapper.Map<ProductCategoryDto>(productCategory);

            return Ok(response);
        }
    }
}