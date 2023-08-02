using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingProgress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingProgressEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteTrainingProgressRequest>.WithActionResult<
        DeleteTrainingProgressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingProgress> _repository;
        private readonly IRepository<TrainingProgress> _trainingProgressReadRepository;

        public Delete(IRepository<TrainingProgress> TrainingProgressRepository,
            IRepository<TrainingProgress> TrainingProgressReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = TrainingProgressRepository;
            _trainingProgressReadRepository = TrainingProgressReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/trainingProgresses/{TrainingProgressId}")]
        [SwaggerOperation(
            Summary = "Deletes an TrainingProgress",
            Description = "Deletes an TrainingProgress",
            OperationId = "trainingProgresses.delete",
            Tags = new[] { "TrainingProgressEndpoints" })
        ]
        public override async Task<ActionResult<DeleteTrainingProgressResponse>> HandleAsync(
            [FromRoute] DeleteTrainingProgressRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteTrainingProgressResponse(request.CorrelationId());

            var trainingProgress = await _trainingProgressReadRepository.GetByIdAsync(request.TrainingProgressId);

            if (trainingProgress == null)
            {
                return NotFound();
            }


            var trainingProgressDeletedEvent = new TrainingProgressDeletedEvent(trainingProgress, "Mongo-History");
            _messagePublisher.Publish(trainingProgressDeletedEvent);

            await _repository.DeleteAsync(trainingProgress);

            return Ok(response);
        }
    }
}