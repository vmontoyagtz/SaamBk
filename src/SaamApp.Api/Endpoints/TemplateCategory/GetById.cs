using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TemplateCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateCategoryEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdTemplateCategoryRequest>.WithActionResult<
        GetByIdTemplateCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TemplateCategory> _repository;

        public GetById(
            IRepository<TemplateCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/templateCategories/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a TemplateCategory by Id",
            Description = "Gets a TemplateCategory by Id",
            OperationId = "templateCategories.GetById",
            Tags = new[] { "TemplateCategoryEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTemplateCategoryResponse>> HandleAsync(
            [FromRoute] GetByIdTemplateCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTemplateCategoryResponse(request.CorrelationId());

            var templateCategory = await _repository.GetByIdAsync(request.RowId);
            if (templateCategory is null)
            {
                return NotFound();
            }

            response.TemplateCategory = _mapper.Map<TemplateCategoryDto>(templateCategory);

            return Ok(response);
        }
    }
}