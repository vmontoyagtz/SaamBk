using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.State;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.StateEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListStateRequest>.WithActionResult<ListStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<State> _repository;

        public List(IRepository<State> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/states")]
        [SwaggerOperation(
            Summary = "List States",
            Description = "List States",
            OperationId = "states.List",
            Tags = new[] { "StateEndpoints" })
        ]
        public override async Task<ActionResult<ListStateResponse>> HandleAsync([FromQuery] ListStateRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListStateResponse(request.CorrelationId());

            var spec = new StateGetListSpec();
            var states = await _repository.ListAsync(spec);
            if (states is null)
            {
                return NotFound();
            }

            response.States = _mapper.Map<List<StateDto>>(states);
            response.Count = response.States.Count;

            return Ok(response);
        }
    }
}