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
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsAiAreaExpertiseRequest>.WithActionResult<
        GetByIdAiAreaExpertiseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiAreaExpertise> _repository;

        public GetByRelsIds(
            IRepository<AiAreaExpertise> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiAreaExpertises/{ModelId}/{RegionAreaAdvisorCategoryId}/{TenantId}")]
        [SwaggerOperation(
            Summary = "Get a AiAreaExpertise by rel Ids",
            Description = "Gets a AiAreaExpertise by rel Ids",
            OperationId = "aiAreaExpertises.GetByRelsIds",
            Tags = new[] { "AiAreaExpertiseEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiAreaExpertiseResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsAiAreaExpertiseRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiAreaExpertiseResponse(request.CorrelationId());

            var spec = new AiAreaExpertiseByRelIdsSpec(request.ModelId, request.RegionAreaAdvisorCategoryId,
                request.TenantId);

            var aiAreaExpertise = await _repository.FirstOrDefaultAsync(spec);


            if (aiAreaExpertise is null)
            {
                return NotFound();
            }

            response.AiAreaExpertise = _mapper.Map<AiAreaExpertiseDto>(aiAreaExpertise);

            return Ok(response);
        }
    }
}