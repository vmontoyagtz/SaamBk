using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TemplateType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateTypeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListTemplateTypeRequest>.WithActionResult<
        ListTemplateTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TemplateType> _repository;

        public List(IRepository<TemplateType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/templateTypes")]
        [SwaggerOperation(
            Summary = "List TemplateTypes",
            Description = "List TemplateTypes",
            OperationId = "templateTypes.List",
            Tags = new[] { "TemplateTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListTemplateTypeResponse>> HandleAsync(
            [FromQuery] ListTemplateTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListTemplateTypeResponse(request.CorrelationId());

            var spec = new TemplateTypeGetListSpec();
            var templateTypes = await _repository.ListAsync(spec);
            if (templateTypes is null)
            {
                return NotFound();
            }

            response.TemplateTypes = _mapper.Map<List<TemplateTypeDto>>(templateTypes);
            response.Count = response.TemplateTypes.Count;

            return Ok(response);
        }
    }
}