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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdStateRequest>.WithActionResult<
        GetByIdStateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<State> _repository;

        public GetByIdWithIncludes(
            IRepository<State> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/states/i/{StateId}")]
        [SwaggerOperation(
            Summary = "Get a State by Id With Includes",
            Description = "Gets a State by Id With Includes",
            OperationId = "states.GetByIdWithIncludes",
            Tags = new[] { "StateEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdStateResponse>> HandleAsync(
            [FromRoute] GetByIdStateRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdStateResponse(request.CorrelationId());

            var spec = new StateByIdWithIncludesSpec(request.StateId);

            var state = await _repository.FirstOrDefaultAsync(spec);


            if (state is null)
            {
                return NotFound();
            }

            response.State = _mapper.Map<StateDto>(state);

            return Ok(response);
        }
    }
}