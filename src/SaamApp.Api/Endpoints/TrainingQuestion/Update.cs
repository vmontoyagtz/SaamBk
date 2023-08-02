using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingQuestion;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.TrainingQuestionEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateTrainingQuestionRequest>.WithActionResult<
        UpdateTrainingQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingQuestion> _repository;

        public Update(
            IRepository<TrainingQuestion> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/trainingQuestions")]
        [SwaggerOperation(
            Summary = "Updates a TrainingQuestion",
            Description = "Updates a TrainingQuestion",
            OperationId = "trainingQuestions.update",
            Tags = new[] { "TrainingQuestionEndpoints" })
        ]
        public override async Task<ActionResult<UpdateTrainingQuestionResponse>> HandleAsync(
            UpdateTrainingQuestionRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateTrainingQuestionResponse(request.CorrelationId());

            var tqrqaqToUpdate = _mapper.Map<TrainingQuestion>(request);

            var trainingQuestionToUpdateTest = await _repository.GetByIdAsync(request.TrainingQuestionId);
            if (trainingQuestionToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(tqrqaqToUpdate);

            var trainingQuestionUpdatedEvent = new TrainingQuestionUpdatedEvent(tqrqaqToUpdate, "Mongo-History");
            _messagePublisher.Publish(trainingQuestionUpdatedEvent);

            var dto = _mapper.Map<TrainingQuestionDto>(tqrqaqToUpdate);
            response.TrainingQuestion = dto;

            return Ok(response);
        }
    }
}