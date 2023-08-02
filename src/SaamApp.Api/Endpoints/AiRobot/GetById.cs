using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiRobot;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiRobotEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAiRobotRequest>.WithActionResult<
        GetByIdAiRobotResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiRobot> _repository;

        public GetById(
            IRepository<AiRobot> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiRobots/{AiRobotId}")]
        [SwaggerOperation(
            Summary = "Get a AiRobot by Id",
            Description = "Gets a AiRobot by Id",
            OperationId = "aiRobots.GetById",
            Tags = new[] { "AiRobotEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiRobotResponse>> HandleAsync(
            [FromRoute] GetByIdAiRobotRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiRobotResponse(request.CorrelationId());

            var aiRobot = await _repository.GetByIdAsync(request.AiRobotId);
            if (aiRobot is null)
            {
                return NotFound();
            }

            response.AiRobot = _mapper.Map<AiRobotDto>(aiRobot);

            return Ok(response);
        }
    }
}