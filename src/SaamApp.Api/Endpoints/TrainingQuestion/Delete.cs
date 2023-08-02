using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingQuestion;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingQuestionEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteTrainingQuestionRequest>.WithActionResult<
        DeleteTrainingQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingQuestion> _repository;
        private readonly IRepository<TrainingQuestionOption> _trainingQuestionOptionRepository;
        private readonly IRepository<TrainingQuestion> _trainingQuestionReadRepository;

        public Delete(IRepository<TrainingQuestion> TrainingQuestionRepository,
            IRepository<TrainingQuestion> TrainingQuestionReadRepository,
            IRepository<TrainingQuestionOption> trainingQuestionOptionRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = TrainingQuestionRepository;
            _trainingQuestionReadRepository = TrainingQuestionReadRepository;
            _trainingQuestionOptionRepository = trainingQuestionOptionRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/trainingQuestions/{TrainingQuestionId}")]
        [SwaggerOperation(
            Summary = "Deletes an TrainingQuestion",
            Description = "Deletes an TrainingQuestion",
            OperationId = "trainingQuestions.delete",
            Tags = new[] { "TrainingQuestionEndpoints" })
        ]
        public override async Task<ActionResult<DeleteTrainingQuestionResponse>> HandleAsync(
            [FromRoute] DeleteTrainingQuestionRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteTrainingQuestionResponse(request.CorrelationId());

            var trainingQuestion = await _trainingQuestionReadRepository.GetByIdAsync(request.TrainingQuestionId);

            if (trainingQuestion == null)
            {
                return NotFound();
            }

            var trainingQuestionOptionSpec =
                new GetTrainingQuestionOptionWithTrainingQuestionKeySpec(trainingQuestion.TrainingQuestionId);
            var trainingQuestionOptions = await _trainingQuestionOptionRepository.ListAsync(trainingQuestionOptionSpec);
            await _trainingQuestionOptionRepository
                .DeleteRangeAsync(trainingQuestionOptions); // you could use soft delete with IsDeleted = true

            var trainingQuestionDeletedEvent = new TrainingQuestionDeletedEvent(trainingQuestion, "Mongo-History");
            _messagePublisher.Publish(trainingQuestionDeletedEvent);

            await _repository.DeleteAsync(trainingQuestion);

            return Ok(response);
        }
    }
}