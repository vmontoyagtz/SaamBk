using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiRobot;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiRobotEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAiRobotRequest>.WithActionResult<
        GetByIdAiRobotResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiRobot> _repository;

        public GetByIdWithIncludes(
            IRepository<AiRobot> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiRobots/i/{AiRobotId}")]
        [SwaggerOperation(
            Summary = "Get a AiRobot by Id With Includes",
            Description = "Gets a AiRobot by Id With Includes",
            OperationId = "aiRobots.GetByIdWithIncludes",
            Tags = new[] { "AiRobotEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiRobotResponse>> HandleAsync(
            [FromRoute] GetByIdAiRobotRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiRobotResponse(request.CorrelationId());

            var spec = new AiRobotByIdWithIncludesSpec(request.AiRobotId);

            var aiRobot = await _repository.FirstOrDefaultAsync(spec);


            if (aiRobot is null)
            {
                return NotFound();
            }

            response.AiRobot = _mapper.Map<AiRobotDto>(aiRobot);

            return Ok(response);
        }
    }
}