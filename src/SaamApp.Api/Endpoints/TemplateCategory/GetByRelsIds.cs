using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TemplateCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateCategoryEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsTemplateCategoryRequest>.WithActionResult<
        GetByIdTemplateCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TemplateCategory> _repository;

        public GetByRelsIds(
            IRepository<TemplateCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/templateCategories/{RegionAreaAdvisorCategoryId}/{ComissionId}/{TemplateId}/{TenantId}")]
        [SwaggerOperation(
            Summary = "Get a TemplateCategory by rel Ids",
            Description = "Gets a TemplateCategory by rel Ids",
            OperationId = "templateCategories.GetByRelsIds",
            Tags = new[] { "TemplateCategoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTemplateCategoryResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsTemplateCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTemplateCategoryResponse(request.CorrelationId());

            var spec = new TemplateCategoryByRelIdsSpec(request.RegionAreaAdvisorCategoryId, request.ComissionId,
                request.TemplateId, request.TenantId);

            var templateCategory = await _repository.FirstOrDefaultAsync(spec);


            if (templateCategory is null)
            {
                return NotFound();
            }

            response.TemplateCategory = _mapper.Map<TemplateCategoryDto>(templateCategory);

            return Ok(response);
        }
    }
}