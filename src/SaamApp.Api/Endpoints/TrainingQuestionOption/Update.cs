using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingQuestionOption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.TrainingQuestionOptionEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateTrainingQuestionOptionRequest>.WithActionResult<
        UpdateTrainingQuestionOptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingQuestionOption> _repository;

        public Update(
            IRepository<TrainingQuestionOption> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/trainingQuestionOptions")]
        [SwaggerOperation(
            Summary = "Updates a TrainingQuestionOption",
            Description = "Updates a TrainingQuestionOption",
            OperationId = "trainingQuestionOptions.update",
            Tags = new[] { "TrainingQuestionOptionEndpoints" })
        ]
        public override async Task<ActionResult<UpdateTrainingQuestionOptionResponse>> HandleAsync(
            UpdateTrainingQuestionOptionRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateTrainingQuestionOptionResponse(request.CorrelationId());

            var tqorqoaqoToUpdate = _mapper.Map<TrainingQuestionOption>(request);

            var trainingQuestionOptionToUpdateTest = await _repository.GetByIdAsync(request.TrainingQuestionOptionId);
            if (trainingQuestionOptionToUpdateTest is null)
            {
                return NotFound();
            }

            tqorqoaqoToUpdate.UpdateTrainingQuestionForTrainingQuestionOption(request.TrainingQuestionId);
            await _repository.UpdateAsync(tqorqoaqoToUpdate);

            var trainingQuestionOptionUpdatedEvent =
                new TrainingQuestionOptionUpdatedEvent(tqorqoaqoToUpdate, "Mongo-History");
            _messagePublisher.Publish(trainingQuestionOptionUpdatedEvent);

            var dto = _mapper.Map<TrainingQuestionOptionDto>(tqorqoaqoToUpdate);
            response.TrainingQuestionOption = dto;

            return Ok(response);
        }
    }
}