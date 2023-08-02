using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AiRobotCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiRobotCategoryEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAiRobotCategoryRequest>.WithActionResult<
        CreateAiRobotCategoryResponse>
    {
        private readonly IRepository<AiRobot> _aiRobotRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AiRobotCategory> _repository;

        public Create(
            IRepository<AiRobotCategory> repository,
            IRepository<AiRobot> aiRobotRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _aiRobotRepository = aiRobotRepository;
        }

        [HttpPost("api/aiRobotCategories")]
        [SwaggerOperation(
            Summary = "Creates a new AiRobotCategory",
            Description = "Creates a new AiRobotCategory",
            OperationId = "aiRobotCategories.create",
            Tags = new[] { "AiRobotCategoryEndpoints" })
        ]
        public override async Task<ActionResult<CreateAiRobotCategoryResponse>> HandleAsync(
            CreateAiRobotCategoryRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAiRobotCategoryResponse(request.CorrelationId());

            //var aiRobot = await _aiRobotRepository.GetByIdAsync(request.AiRobotId);// parent entity

            var newAiRobotCategory = new AiRobotCategory(
                request.AiRobotId,
                request.ComissionId,
                request.RegionAreaAdvisorCategoryId
            );


            await _repository.AddAsync(newAiRobotCategory);

            _logger.LogInformation(
                $"AiRobotCategory created  with Id {newAiRobotCategory.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AiRobotCategoryDto>(newAiRobotCategory);

            var aiRobotCategoryCreatedEvent = new AiRobotCategoryCreatedEvent(newAiRobotCategory, "Mongo-History");
            _messagePublisher.Publish(aiRobotCategoryCreatedEvent);

            response.AiRobotCategory = dto;


            return Ok(response);
        }
    }
}