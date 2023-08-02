using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingProgress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.TrainingProgressEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateTrainingProgressRequest>.WithActionResult<
        UpdateTrainingProgressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingProgress> _repository;

        public Update(
            IRepository<TrainingProgress> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/trainingProgresses")]
        [SwaggerOperation(
            Summary = "Updates a TrainingProgress",
            Description = "Updates a TrainingProgress",
            OperationId = "trainingProgresses.update",
            Tags = new[] { "TrainingProgressEndpoints" })
        ]
        public override async Task<ActionResult<UpdateTrainingProgressResponse>> HandleAsync(
            UpdateTrainingProgressRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateTrainingProgressResponse(request.CorrelationId());

            var tprpapToUpdate = _mapper.Map<TrainingProgress>(request);

            var trainingProgressToUpdateTest = await _repository.GetByIdAsync(request.TrainingProgressId);
            if (trainingProgressToUpdateTest is null)
            {
                return NotFound();
            }

            //tprpapToUpdate.UpdateAdvisorForTrainingProgress(request.AdvisorId);
            //tprpapToUpdate.UpdateTrainingLessonForTrainingProgress(request.TrainingLessonId);
            await _repository.UpdateAsync(tprpapToUpdate);

            var trainingProgressUpdatedEvent = new TrainingProgressUpdatedEvent(tprpapToUpdate, "Mongo-History");
            _messagePublisher.Publish(trainingProgressUpdatedEvent);

            var dto = _mapper.Map<TrainingProgressDto>(tprpapToUpdate);
            response.TrainingProgress = dto;

            return Ok(response);
        }
    }
}