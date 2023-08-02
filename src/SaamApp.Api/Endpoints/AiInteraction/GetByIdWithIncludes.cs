using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiInteraction;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiInteractionEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAiInteractionRequest>.WithActionResult<
        GetByIdAiInteractionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiInteraction> _repository;

        public GetByIdWithIncludes(
            IRepository<AiInteraction> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiInteractions/i/{AiInteractionId}")]
        [SwaggerOperation(
            Summary = "Get a AiInteraction by Id With Includes",
            Description = "Gets a AiInteraction by Id With Includes",
            OperationId = "aiInteractions.GetByIdWithIncludes",
            Tags = new[] { "AiInteractionEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiInteractionResponse>> HandleAsync(
            [FromRoute] GetByIdAiInteractionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiInteractionResponse(request.CorrelationId());

            var spec = new AiInteractionByIdWithIncludesSpec(request.AiInteractionId);

            var aiInteraction = await _repository.FirstOrDefaultAsync(spec);


            if (aiInteraction is null)
            {
                return NotFound();
            }

            response.AiInteraction = _mapper.Map<AiInteractionDto>(aiInteraction);

            return Ok(response);
        }
    }
}