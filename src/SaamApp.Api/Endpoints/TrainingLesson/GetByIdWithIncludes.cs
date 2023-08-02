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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdTrainingLessonRequest>.WithActionResult<
        GetByIdTrainingLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TrainingLesson> _repository;

        public GetByIdWithIncludes(
            IRepository<TrainingLesson> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/trainingLessons/i/{TrainingLessonId}")]
        [SwaggerOperation(
            Summary = "Get a TrainingLesson by Id With Includes",
            Description = "Gets a TrainingLesson by Id With Includes",
            OperationId = "trainingLessons.GetByIdWithIncludes",
            Tags = new[] { "TrainingLessonEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTrainingLessonResponse>> HandleAsync(
            [FromRoute] GetByIdTrainingLessonRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTrainingLessonResponse(request.CorrelationId());

            var spec = new TrainingLessonByIdWithIncludesSpec(request.TrainingLessonId);

            var trainingLesson = await _repository.FirstOrDefaultAsync(spec);


            if (trainingLesson is null)
            {
                return NotFound();
            }

            response.TrainingLesson = _mapper.Map<TrainingLessonDto>(trainingLesson);

            return Ok(response);
        }
    }
}