using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.TrainingProgress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingProgressEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateTrainingProgressRequest>.WithActionResult<
        CreateTrainingProgressResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TrainingProgress> _repository;

        public Create(
            IRepository<TrainingProgress> repository,
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

        [HttpPost("api/trainingProgresses")]
        [SwaggerOperation(
            Summary = "Creates a new TrainingProgress",
            Description = "Creates a new TrainingProgress",
            OperationId = "trainingProgresses.create",
            Tags = new[] { "TrainingProgressEndpoints" })
        ]
        public override async Task<ActionResult<CreateTrainingProgressResponse>> HandleAsync(
            CreateTrainingProgressRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateTrainingProgressResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newTrainingProgress = new TrainingProgress(
                Guid.NewGuid(),
                request.AdvisorId,
                request.TrainingLessonId,
                request.TrainingProgressPercentage,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.IsDeleted,
                request.TenantId
            );


            await _repository.AddAsync(newTrainingProgress);

            _logger.LogInformation(
                $"TrainingProgress created  with Id {newTrainingProgress.TrainingProgressId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<TrainingProgressDto>(newTrainingProgress);

            var trainingProgressCreatedEvent = new TrainingProgressCreatedEvent(newTrainingProgress, "Mongo-History");
            _messagePublisher.Publish(trainingProgressCreatedEvent);

            response.TrainingProgress = dto;


            return Ok(response);
        }
    }
}