using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingLesson;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.TrainingLessonEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateTrainingLessonRequest>.WithActionResult<
        UpdateTrainingLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingLesson> _repository;

        public Update(
            IRepository<TrainingLesson> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/trainingLessons")]
        [SwaggerOperation(
            Summary = "Updates a TrainingLesson",
            Description = "Updates a TrainingLesson",
            OperationId = "trainingLessons.update",
            Tags = new[] { "TrainingLessonEndpoints" })
        ]
        public override async Task<ActionResult<UpdateTrainingLessonResponse>> HandleAsync(
            UpdateTrainingLessonRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateTrainingLessonResponse(request.CorrelationId());

            var tlrlalToUpdate = _mapper.Map<TrainingLesson>(request);

            var trainingLessonToUpdateTest = await _repository.GetByIdAsync(request.TrainingLessonId);
            if (trainingLessonToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(tlrlalToUpdate);

            var trainingLessonUpdatedEvent = new TrainingLessonUpdatedEvent(tlrlalToUpdate, "Mongo-History");
            _messagePublisher.Publish(trainingLessonUpdatedEvent);

            var dto = _mapper.Map<TrainingLessonDto>(tlrlalToUpdate);
            response.TrainingLesson = dto;

            return Ok(response);
        }
    }
}