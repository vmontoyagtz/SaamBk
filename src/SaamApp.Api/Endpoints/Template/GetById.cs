using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Template;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdTemplateRequest>.WithActionResult<
        GetByIdTemplateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Template> _repository;

        public GetById(
            IRepository<Template> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/templates/{TemplateId}")]
        [SwaggerOperation(
            Summary = "Get a Template by Id",
            Description = "Gets a Template by Id",
            OperationId = "templates.GetById",
            Tags = new[] { "TemplateEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTemplateResponse>> HandleAsync(
            [FromRoute] GetByIdTemplateRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTemplateResponse(request.CorrelationId());

            var template = await _repository.GetByIdAsync(request.TemplateId);
            if (template is null)
            {
                return NotFound();
            }

            response.Template = _mapper.Map<TemplateDto>(template);

            return Ok(response);
        }
    }
}