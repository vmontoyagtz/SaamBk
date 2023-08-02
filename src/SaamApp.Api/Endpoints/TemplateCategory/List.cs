using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListTemplateCategoryRequest>.WithActionResult<
        ListTemplateCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TemplateCategory> _repository;

        public List(IRepository<TemplateCategory> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/templateCategories")]
        [SwaggerOperation(
            Summary = "List TemplateCategories",
            Description = "List TemplateCategories",
            OperationId = "templateCategories.List",
            Tags = new[] { "TemplateCategoryEndpoints" })
        ]
        public override async Task<ActionResult<ListTemplateCategoryResponse>> HandleAsync(
            [FromQuery] ListTemplateCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListTemplateCategoryResponse(request.CorrelationId());

            var spec = new TemplateCategoryGetListSpec();
            var templateCategories = await _repository.ListAsync(spec);
            if (templateCategories is null)
            {
                return NotFound();
            }

            response.TemplateCategories = _mapper.Map<List<TemplateCategoryDto>>(templateCategories);
            response.Count = response.TemplateCategories.Count;

            return Ok(response);
        }
    }
}