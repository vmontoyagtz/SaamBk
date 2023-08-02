using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Template;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListTemplateRequest>.WithActionResult<ListTemplateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Template> _repository;

        public List(IRepository<Template> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/templates")]
        [SwaggerOperation(
            Summary = "List Templates",
            Description = "List Templates",
            OperationId = "templates.List",
            Tags = new[] { "TemplateEndpoints" })
        ]
        public override async Task<ActionResult<ListTemplateResponse>> HandleAsync(
            [FromQuery] ListTemplateRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListTemplateResponse(request.CorrelationId());

            var spec = new TemplateGetListSpec();
            var templates = await _repository.ListAsync(spec);
            if (templates is null)
            {
                return NotFound();
            }

            response.Templates = _mapper.Map<List<TemplateDto>>(templates);
            response.Count = response.Templates.Count;

            return Ok(response);
        }
    }
}