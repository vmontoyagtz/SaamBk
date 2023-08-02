using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingLesson;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingLessonEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteTrainingLessonRequest>.WithActionResult<
        DeleteTrainingLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingLesson> _repository;
        private readonly IRepository<TrainingLesson> _trainingLessonReadRepository;
        private readonly IRepository<TrainingProgress> _trainingProgressRepository;

        public Delete(IRepository<TrainingLesson> TrainingLessonRepository,
            IRepository<TrainingLesson> TrainingLessonReadRepository,
            IRepository<TrainingProgress> trainingProgressRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = TrainingLessonRepository;
            _trainingLessonReadRepository = TrainingLessonReadRepository;
            _trainingProgressRepository = trainingProgressRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/trainingLessons/{TrainingLessonId}")]
        [SwaggerOperation(
            Summary = "Deletes an TrainingLesson",
            Description = "Deletes an TrainingLesson",
            OperationId = "trainingLessons.delete",
            Tags = new[] { "TrainingLessonEndpoints" })
        ]
        public override async Task<ActionResult<DeleteTrainingLessonResponse>> HandleAsync(
            [FromRoute] DeleteTrainingLessonRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteTrainingLessonResponse(request.CorrelationId());

            var trainingLesson = await _trainingLessonReadRepository.GetByIdAsync(request.TrainingLessonId);

            if (trainingLesson == null)
            {
                return NotFound();
            }

            var trainingProgressSpec =
                new GetTrainingProgressWithTrainingLessonKeySpec(trainingLesson.TrainingLessonId);
            var trainingProgresses = await _trainingProgressRepository.ListAsync(trainingProgressSpec);
            await _trainingProgressRepository
                .DeleteRangeAsync(trainingProgresses); // you could use soft delete with IsDeleted = true

            var trainingLessonDeletedEvent = new TrainingLessonDeletedEvent(trainingLesson, "Mongo-History");
            _messagePublisher.Publish(trainingLessonDeletedEvent);

            await _repository.DeleteAsync(trainingLesson);

            return Ok(response);
        }
    }
}