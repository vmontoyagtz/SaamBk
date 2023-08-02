using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.InteractionType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.InteractionTypeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdInteractionTypeRequest>.WithActionResult<
        GetByIdInteractionTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<InteractionType> _repository;

        public GetById(
            IRepository<InteractionType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/interactionTypes/{InteractionTypeId}")]
        [SwaggerOperation(
            Summary = "Get a InteractionType by Id",
            Description = "Gets a InteractionType by Id",
            OperationId = "interactionTypes.GetById",
            Tags = new[] { "InteractionTypeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdInteractionTypeResponse>> HandleAsync(
            [FromRoute] GetByIdInteractionTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdInteractionTypeResponse(request.CorrelationId());

            var interactionType = await _repository.GetByIdAsync(request.InteractionTypeId);
            if (interactionType is null)
            {
                return NotFound();
            }

            response.InteractionType = _mapper.Map<InteractionTypeDto>(interactionType);

            return Ok(response);
        }
    }
}