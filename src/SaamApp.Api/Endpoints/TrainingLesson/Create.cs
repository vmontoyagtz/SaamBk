using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.TrainingLesson;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingLessonEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateTrainingLessonRequest>.WithActionResult<
        CreateTrainingLessonResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingLesson> _repository;

        public Create(
            IRepository<TrainingLesson> repository,
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

        [HttpPost("api/trainingLessons")]
        [SwaggerOperation(
            Summary = "Creates a new TrainingLesson",
            Description = "Creates a new TrainingLesson",
            OperationId = "trainingLessons.create",
            Tags = new[] { "TrainingLessonEndpoints" })
        ]
        public override async Task<ActionResult<CreateTrainingLessonResponse>> HandleAsync(
            CreateTrainingLessonRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateTrainingLessonResponse(request.CorrelationId());


            var newTrainingLesson = new TrainingLesson(
                Guid.NewGuid(),
                request.TrainingLessonTitle,
                request.TrainingLessonDescription,
                request.TrainingLessonVimeoVideoId,
                request.TrainingLessonVideoDuration,
                request.TrainingLessonUserType,
                request.TrainingLessonPreviousLesson,
                request.TenantId
            );


            await _repository.AddAsync(newTrainingLesson);

            _logger.LogInformation(
                $"TrainingLesson created  with Id {newTrainingLesson.TrainingLessonId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<TrainingLessonDto>(newTrainingLesson);

            var trainingLessonCreatedEvent = new TrainingLessonCreatedEvent(newTrainingLesson, "Mongo-History");
            _messagePublisher.Publish(trainingLessonCreatedEvent);

            response.TrainingLesson = dto;


            return Ok(response);
        }
    }
}