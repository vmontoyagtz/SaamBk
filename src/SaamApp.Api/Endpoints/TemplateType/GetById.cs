using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TemplateType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateTypeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdTemplateTypeRequest>.WithActionResult<
        GetByIdTemplateTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TemplateType> _repository;

        public GetById(
            IRepository<TemplateType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/templateTypes/{TemplateTypeId}")]
        [SwaggerOperation(
            Summary = "Get a TemplateType by Id",
            Description = "Gets a TemplateType by Id",
            OperationId = "templateTypes.GetById",
            Tags = new[] { "TemplateTypeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTemplateTypeResponse>> HandleAsync(
            [FromRoute] GetByIdTemplateTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTemplateTypeResponse(request.CorrelationId());

            var templateType = await _repository.GetByIdAsync(request.TemplateTypeId);
            if (templateType is null)
            {
                return NotFound();
            }

            response.TemplateType = _mapper.Map<TemplateTypeDto>(templateType);

            return Ok(response);
        }
    }
}