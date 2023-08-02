using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListAiRobotRequest>.WithActionResult<ListAiRobotResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiRobot> _repository;

        public List(IRepository<AiRobot> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiRobots")]
        [SwaggerOperation(
            Summary = "List AiRobots",
            Description = "List AiRobots",
            OperationId = "aiRobots.List",
            Tags = new[] { "AiRobotEndpoints" })
        ]
        public override async Task<ActionResult<ListAiRobotResponse>> HandleAsync(
            [FromQuery] ListAiRobotRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAiRobotResponse(request.CorrelationId());

            var spec = new AiRobotGetListSpec();
            var aiRobots = await _repository.ListAsync(spec);
            if (aiRobots is null)
            {
                return NotFound();
            }

            response.AiRobots = _mapper.Map<List<AiRobotDto>>(aiRobots);
            response.Count = response.AiRobots.Count;

            return Ok(response);
        }
    }
}