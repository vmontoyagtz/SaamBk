using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingLesson;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingLessonEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListTrainingLessonRequest>.WithActionResult<
        ListTrainingLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TrainingLesson> _repository;

        public List(IRepository<TrainingLesson> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/trainingLessons")]
        [SwaggerOperation(
            Summary = "List TrainingLessons",
            Description = "List TrainingLessons",
            OperationId = "trainingLessons.List",
            Tags = new[] { "TrainingLessonEndpoints" })
        ]
        public override async Task<ActionResult<ListTrainingLessonResponse>> HandleAsync(
            [FromQuery] ListTrainingLessonRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListTrainingLessonResponse(request.CorrelationId());

            var spec = new TrainingLessonGetListSpec();
            var trainingLessons = await _repository.ListAsync(spec);
            if (trainingLessons is null)
            {
                return NotFound();
            }

            response.TrainingLessons = _mapper.Map<List<TrainingLessonDto>>(trainingLessons);
            response.Count = response.TrainingLessons.Count;

            return Ok(response);
        }
    }
}