using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiAreaExpertise;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiAreaExpertiseEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAiAreaExpertiseRequest>.WithActionResult<
        GetByIdAiAreaExpertiseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiAreaExpertise> _repository;

        public GetById(
            IRepository<AiAreaExpertise> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiAreaExpertises/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a AiAreaExpertise by Id",
            Description = "Gets a AiAreaExpertise by Id",
            OperationId = "aiAreaExpertises.GetById",
            Tags = new[] { "AiAreaExpertiseEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiAreaExpertiseResponse>> HandleAsync(
            [FromRoute] GetByIdAiAreaExpertiseRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiAreaExpertiseResponse(request.CorrelationId());

            var aiAreaExpertise = await _repository.GetByIdAsync(request.RowId);
            if (aiAreaExpertise is null)
            {
                return NotFound();
            }

            response.AiAreaExpertise = _mapper.Map<AiAreaExpertiseDto>(aiAreaExpertise);

            return Ok(response);
        }
    }
}