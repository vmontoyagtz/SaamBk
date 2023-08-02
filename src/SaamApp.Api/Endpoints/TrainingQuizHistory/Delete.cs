using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingQuizHistory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingQuizHistoryEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteTrainingQuizHistoryRequest>.WithActionResult<
        DeleteTrainingQuizHistoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingQuizHistory> _repository;
        private readonly IRepository<TrainingQuizHistory> _trainingQuizHistoryReadRepository;

        public Delete(IRepository<TrainingQuizHistory> TrainingQuizHistoryRepository,
            IRepository<TrainingQuizHistory> TrainingQuizHistoryReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = TrainingQuizHistoryRepository;
            _trainingQuizHistoryReadRepository = TrainingQuizHistoryReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/trainingQuizHistories/{TrainingQuizHistoryId}")]
        [SwaggerOperation(
            Summary = "Deletes an TrainingQuizHistory",
            Description = "Deletes an TrainingQuizHistory",
            OperationId = "trainingQuizHistories.delete",
            Tags = new[] { "TrainingQuizHistoryEndpoints" })
        ]
        public override async Task<ActionResult<DeleteTrainingQuizHistoryResponse>> HandleAsync(
            [FromRoute] DeleteTrainingQuizHistoryRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteTrainingQuizHistoryResponse(request.CorrelationId());

            var trainingQuizHistory =
                await _trainingQuizHistoryReadRepository.GetByIdAsync(request.TrainingQuizHistoryId);

            if (trainingQuizHistory == null)
            {
                return NotFound();
            }


            var trainingQuizHistoryDeletedEvent =
                new TrainingQuizHistoryDeletedEvent(trainingQuizHistory, "Mongo-History");
            _messagePublisher.Publish(trainingQuizHistoryDeletedEvent);

            await _repository.DeleteAsync(trainingQuizHistory);

            return Ok(response);
        }
    }
}