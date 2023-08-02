using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingLesson;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingLessonEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdTrainingLessonRequest>.WithActionResult<
        GetByIdTrainingLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TrainingLesson> _repository;

        public GetById(
            IRepository<TrainingLesson> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/trainingLessons/{TrainingLessonId}")]
        [SwaggerOperation(
            Summary = "Get a TrainingLesson by Id",
            Description = "Gets a TrainingLesson by Id",
            OperationId = "trainingLessons.GetById",
            Tags = new[] { "TrainingLessonEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTrainingLessonResponse>> HandleAsync(
            [FromRoute] GetByIdTrainingLessonRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTrainingLessonResponse(request.CorrelationId());

            var trainingLesson = await _repository.GetByIdAsync(request.TrainingLessonId);
            if (trainingLesson is null)
            {
                return NotFound();
            }

            response.TrainingLesson = _mapper.Map<TrainingLessonDto>(trainingLesson);

            return Ok(response);
        }
    }
}