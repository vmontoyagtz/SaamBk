using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.TrainingQuizHistory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingQuizHistoryEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateTrainingQuizHistoryRequest>.WithActionResult<
        CreateTrainingQuizHistoryResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingQuizHistory> _repository;

        public Create(
            IRepository<TrainingQuizHistory> repository,
            IRepository<Advisor> advisorRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _advisorRepository = advisorRepository;
        }

        [HttpPost("api/trainingQuizHistories")]
        [SwaggerOperation(
            Summary = "Creates a new TrainingQuizHistory",
            Description = "Creates a new TrainingQuizHistory",
            OperationId = "trainingQuizHistories.create",
            Tags = new[] { "TrainingQuizHistoryEndpoints" })
        ]
        public override async Task<ActionResult<CreateTrainingQuizHistoryResponse>> HandleAsync(
            CreateTrainingQuizHistoryRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateTrainingQuizHistoryResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newTrainingQuizHistory = new TrainingQuizHistory(
                Guid.NewGuid(),
                request.AdvisorId,
                request.TrainingQuizHistoryAction,
                request.TrainingQuizHistoryStage,
                request.HistoryDate
            );


            await _repository.AddAsync(newTrainingQuizHistory);

            _logger.LogInformation(
                $"TrainingQuizHistory created  with Id {newTrainingQuizHistory.TrainingQuizHistoryId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<TrainingQuizHistoryDto>(newTrainingQuizHistory);

            var trainingQuizHistoryCreatedEvent =
                new TrainingQuizHistoryCreatedEvent(newTrainingQuizHistory, "Mongo-History");
            _messagePublisher.Publish(trainingQuizHistoryCreatedEvent);

            response.TrainingQuizHistory = dto;


            return Ok(response);
        }
    }
}