using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.AiAreaExpertise;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiAreaExpertiseEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateAiAreaExpertiseRequest>.WithActionResult<
        CreateAiAreaExpertiseResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<RegionAreaAdvisorCategory> _regionAreaAdvisorCategoryRepository;
        private readonly IRepository<AiAreaExpertise> _repository;

        public Create(
            IRepository<AiAreaExpertise> repository,
            IRepository<RegionAreaAdvisorCategory> regionAreaAdvisorCategoryRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _regionAreaAdvisorCategoryRepository = regionAreaAdvisorCategoryRepository;
        }

        [HttpPost("api/aiAreaExpertises")]
        [SwaggerOperation(
            Summary = "Creates a new AiAreaExpertise",
            Description = "Creates a new AiAreaExpertise",
            OperationId = "aiAreaExpertises.create",
            Tags = new[] { "AiAreaExpertiseEndpoints" })
        ]
        public override async Task<ActionResult<CreateAiAreaExpertiseResponse>> HandleAsync(
            CreateAiAreaExpertiseRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateAiAreaExpertiseResponse(request.CorrelationId());

            //var regionAreaAdvisorCategory = await _regionAreaAdvisorCategoryRepository.GetByIdAsync(request.RegionAreaAdvisorCategoryId);// parent entity

            var newAiAreaExpertise = new AiAreaExpertise(
                request.RegionAreaAdvisorCategoryId,
                request.ModelId,
                request.TenantId
            );


            await _repository.AddAsync(newAiAreaExpertise);

            _logger.LogInformation(
                $"AiAreaExpertise created  with Id {newAiAreaExpertise.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<AiAreaExpertiseDto>(newAiAreaExpertise);

            var aiAreaExpertiseCreatedEvent = new AiAreaExpertiseCreatedEvent(newAiAreaExpertise, "Mongo-History");
            _messagePublisher.Publish(aiAreaExpertiseCreatedEvent);

            response.AiAreaExpertise = dto;


            return Ok(response);
        }
    }
}