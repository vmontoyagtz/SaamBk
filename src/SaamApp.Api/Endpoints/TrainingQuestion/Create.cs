using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.TrainingQuestion;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingQuestionEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateTrainingQuestionRequest>.WithActionResult<
        CreateTrainingQuestionResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingQuestion> _repository;

        public Create(
            IRepository<TrainingQuestion> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/trainingQuestions")]
        [SwaggerOperation(
            Summary = "Creates a new TrainingQuestion",
            Description = "Creates a new TrainingQuestion",
            OperationId = "trainingQuestions.create",
            Tags = new[] { "TrainingQuestionEndpoints" })
        ]
        public override async Task<ActionResult<CreateTrainingQuestionResponse>> HandleAsync(
            CreateTrainingQuestionRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateTrainingQuestionResponse(request.CorrelationId());


            var newTrainingQuestion = new TrainingQuestion(
                Guid.NewGuid(),
                request.TrainingQuestionValue,
                request.TenantId
            );


            await _repository.AddAsync(newTrainingQuestion);

            _logger.LogInformation(
                $"TrainingQuestion created  with Id {newTrainingQuestion.TrainingQuestionId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<TrainingQuestionDto>(newTrainingQuestion);

            var trainingQuestionCreatedEvent = new TrainingQuestionCreatedEvent(newTrainingQuestion, "Mongo-History");
            _messagePublisher.Publish(trainingQuestionCreatedEvent);

            response.TrainingQuestion = dto;


            return Ok(response);
        }
    }
}