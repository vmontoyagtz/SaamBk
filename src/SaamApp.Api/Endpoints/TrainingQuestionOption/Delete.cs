using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingQuestionOption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingQuestionOptionEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteTrainingQuestionOptionRequest>.WithActionResult<
        DeleteTrainingQuestionOptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingQuestionOption> _repository;
        private readonly IRepository<TrainingQuestionOption> _trainingQuestionOptionReadRepository;

        public Delete(IRepository<TrainingQuestionOption> TrainingQuestionOptionRepository,
            IRepository<TrainingQuestionOption> TrainingQuestionOptionReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = TrainingQuestionOptionRepository;
            _trainingQuestionOptionReadRepository = TrainingQuestionOptionReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/trainingQuestionOptions/{TrainingQuestionOptionId}")]
        [SwaggerOperation(
            Summary = "Deletes an TrainingQuestionOption",
            Description = "Deletes an TrainingQuestionOption",
            OperationId = "trainingQuestionOptions.delete",
            Tags = new[] { "TrainingQuestionOptionEndpoints" })
        ]
        public override async Task<ActionResult<DeleteTrainingQuestionOptionResponse>> HandleAsync(
            [FromRoute] DeleteTrainingQuestionOptionRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteTrainingQuestionOptionResponse(request.CorrelationId());

            var trainingQuestionOption =
                await _trainingQuestionOptionReadRepository.GetByIdAsync(request.TrainingQuestionOptionId);

            if (trainingQuestionOption == null)
            {
                return NotFound();
            }


            var trainingQuestionOptionDeletedEvent =
                new TrainingQuestionOptionDeletedEvent(trainingQuestionOption, "Mongo-History");
            _messagePublisher.Publish(trainingQuestionOptionDeletedEvent);

            await _repository.DeleteAsync(trainingQuestionOption);

            return Ok(response);
        }
    }
}