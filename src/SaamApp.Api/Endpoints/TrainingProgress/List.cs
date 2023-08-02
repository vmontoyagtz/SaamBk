using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingProgress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingProgressEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListTrainingProgressRequest>.WithActionResult<
        ListTrainingProgressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TrainingProgress> _repository;

        public List(IRepository<TrainingProgress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/trainingProgresses")]
        [SwaggerOperation(
            Summary = "List TrainingProgresses",
            Description = "List TrainingProgresses",
            OperationId = "trainingProgresses.List",
            Tags = new[] { "TrainingProgressEndpoints" })
        ]
        public override async Task<ActionResult<ListTrainingProgressResponse>> HandleAsync(
            [FromQuery] ListTrainingProgressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListTrainingProgressResponse(request.CorrelationId());

            var spec = new TrainingProgressGetListSpec();
            var trainingProgresses = await _repository.ListAsync(spec);
            if (trainingProgresses is null)
            {
                return NotFound();
            }

            response.TrainingProgresses = _mapper.Map<List<TrainingProgressDto>>(trainingProgresses);
            response.Count = response.TrainingProgresses.Count;

            return Ok(response);
        }
    }
}