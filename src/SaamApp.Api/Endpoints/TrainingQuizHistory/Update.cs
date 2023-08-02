using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingQuizHistory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.TrainingQuizHistoryEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateTrainingQuizHistoryRequest>.WithActionResult<
        UpdateTrainingQuizHistoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingQuizHistory> _repository;

        public Update(
            IRepository<TrainingQuizHistory> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/trainingQuizHistories")]
        [SwaggerOperation(
            Summary = "Updates a TrainingQuizHistory",
            Description = "Updates a TrainingQuizHistory",
            OperationId = "trainingQuizHistories.update",
            Tags = new[] { "TrainingQuizHistoryEndpoints" })
        ]
        public override async Task<ActionResult<UpdateTrainingQuizHistoryResponse>> HandleAsync(
            UpdateTrainingQuizHistoryRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateTrainingQuizHistoryResponse(request.CorrelationId());

            var tqhrqhaqhToUpdate = _mapper.Map<TrainingQuizHistory>(request);

            var trainingQuizHistoryToUpdateTest = await _repository.GetByIdAsync(request.TrainingQuizHistoryId);
            if (trainingQuizHistoryToUpdateTest is null)
            {
                return NotFound();
            }

            // tqhrqhaqhToUpdate.UpdateAdvisorForTrainingQuizHistory(request.AdvisorId);
            await _repository.UpdateAsync(tqhrqhaqhToUpdate);

            var trainingQuizHistoryUpdatedEvent =
                new TrainingQuizHistoryUpdatedEvent(tqhrqhaqhToUpdate, "Mongo-History");
            _messagePublisher.Publish(trainingQuizHistoryUpdatedEvent);

            var dto = _mapper.Map<TrainingQuizHistoryDto>(tqhrqhaqhToUpdate);
            response.TrainingQuizHistory = dto;

            return Ok(response);
        }
    }
}