using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.TrainingQuestionOption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingQuestionOptionEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateTrainingQuestionOptionRequest>.WithActionResult<
        CreateTrainingQuestionOptionResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingQuestionOption> _repository;
        private readonly IRepository<TrainingQuestion> _trainingQuestionRepository;

        public Create(
            IRepository<TrainingQuestionOption> repository,
            IRepository<TrainingQuestion> trainingQuestionRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _trainingQuestionRepository = trainingQuestionRepository;
        }

        [HttpPost("api/trainingQuestionOptions")]
        [SwaggerOperation(
            Summary = "Creates a new TrainingQuestionOption",
            Description = "Creates a new TrainingQuestionOption",
            OperationId = "trainingQuestionOptions.create",
            Tags = new[] { "TrainingQuestionOptionEndpoints" })
        ]
        public override async Task<ActionResult<CreateTrainingQuestionOptionResponse>> HandleAsync(
            CreateTrainingQuestionOptionRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateTrainingQuestionOptionResponse(request.CorrelationId());

            //var trainingQuestion = await _trainingQuestionRepository.GetByIdAsync(request.TrainingQuestionId);// parent entity

            var newTrainingQuestionOption = new TrainingQuestionOption(
                Guid.NewGuid(),
                request.TrainingQuestionId,
                request.TrainingQuestionOptionValue,
                request.TrainingQuestionOptionAnswer,
                request.TenantId
            );


            await _repository.AddAsync(newTrainingQuestionOption);

            _logger.LogInformation(
                $"TrainingQuestionOption created  with Id {newTrainingQuestionOption.TrainingQuestionOptionId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<TrainingQuestionOptionDto>(newTrainingQuestionOption);

            var trainingQuestionOptionCreatedEvent =
                new TrainingQuestionOptionCreatedEvent(newTrainingQuestionOption, "Mongo-History");
            _messagePublisher.Publish(trainingQuestionOptionCreatedEvent);

            response.TrainingQuestionOption = dto;


            return Ok(response);
        }
    }
}