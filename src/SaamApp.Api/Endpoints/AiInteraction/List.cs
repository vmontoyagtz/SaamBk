using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListAiInteractionRequest>.WithActionResult<
        ListAiInteractionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiInteraction> _repository;

        public List(IRepository<AiInteraction> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiInteractions")]
        [SwaggerOperation(
            Summary = "List AiInteractions",
            Description = "List AiInteractions",
            OperationId = "aiInteractions.List",
            Tags = new[] { "AiInteractionEndpoints" })
        ]
        public override async Task<ActionResult<ListAiInteractionResponse>> HandleAsync(
            [FromQuery] ListAiInteractionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAiInteractionResponse(request.CorrelationId());

            var spec = new AiInteractionGetListSpec();
            var aiInteractions = await _repository.ListAsync(spec);
            if (aiInteractions is null)
            {
                return NotFound();
            }

            response.AiInteractions = _mapper.Map<List<AiInteractionDto>>(aiInteractions);
            response.Count = response.AiInteractions.Count;

            return Ok(response);
        }
    }
}