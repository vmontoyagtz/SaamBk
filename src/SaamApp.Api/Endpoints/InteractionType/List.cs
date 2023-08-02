using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.InteractionType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.InteractionTypeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListInteractionTypeRequest>.WithActionResult<
        ListInteractionTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<InteractionType> _repository;

        public List(IRepository<InteractionType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/interactionTypes")]
        [SwaggerOperation(
            Summary = "List InteractionTypes",
            Description = "List InteractionTypes",
            OperationId = "interactionTypes.List",
            Tags = new[] { "InteractionTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListInteractionTypeResponse>> HandleAsync(
            [FromQuery] ListInteractionTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListInteractionTypeResponse(request.CorrelationId());

            var spec = new InteractionTypeGetListSpec();
            var interactionTypes = await _repository.ListAsync(spec);
            if (interactionTypes is null)
            {
                return NotFound();
            }

            response.InteractionTypes = _mapper.Map<List<InteractionTypeDto>>(interactionTypes);
            response.Count = response.InteractionTypes.Count;

            return Ok(response);
        }
    }
}