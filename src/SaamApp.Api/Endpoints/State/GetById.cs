using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.State;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.StateEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdStateRequest>.WithActionResult<
        GetByIdStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<State> _repository;

        public GetById(
            IRepository<State> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/states/{StateId}")]
        [SwaggerOperation(
            Summary = "Get a State by Id",
            Description = "Gets a State by Id",
            OperationId = "states.GetById",
            Tags = new[] { "StateEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdStateResponse>> HandleAsync(
            [FromRoute] GetByIdStateRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdStateResponse(request.CorrelationId());

            var state = await _repository.GetByIdAsync(request.StateId);
            if (state is null)
            {
                return NotFound();
            }

            response.State = _mapper.Map<StateDto>(state);

            return Ok(response);
        }
    }
}