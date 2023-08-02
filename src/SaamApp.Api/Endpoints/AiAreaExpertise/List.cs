using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiAreaExpertise;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiAreaExpertiseEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAiAreaExpertiseRequest>.WithActionResult<
        ListAiAreaExpertiseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiAreaExpertise> _repository;

        public List(IRepository<AiAreaExpertise> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiAreaExpertises")]
        [SwaggerOperation(
            Summary = "List AiAreaExpertises",
            Description = "List AiAreaExpertises",
            OperationId = "aiAreaExpertises.List",
            Tags = new[] { "AiAreaExpertiseEndpoints" })
        ]
        public override async Task<ActionResult<ListAiAreaExpertiseResponse>> HandleAsync(
            [FromQuery] ListAiAreaExpertiseRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAiAreaExpertiseResponse(request.CorrelationId());

            var spec = new AiAreaExpertiseGetListSpec();
            var aiAreaExpertises = await _repository.ListAsync(spec);
            if (aiAreaExpertises is null)
            {
                return NotFound();
            }

            response.AiAreaExpertises = _mapper.Map<List<AiAreaExpertiseDto>>(aiAreaExpertises);
            response.Count = response.AiAreaExpertises.Count;

            return Ok(response);
        }
    }
}