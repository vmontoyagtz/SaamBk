using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.RegionAreaAdvisorCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.RegionAreaAdvisorCategoryEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateRegionAreaAdvisorCategoryRequest>.WithActionResult<
        CreateRegionAreaAdvisorCategoryResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<RegionAreaAdvisorCategory> _repository;

        public Create(
            IRepository<RegionAreaAdvisorCategory> repository,
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

        [HttpPost("api/regionAreaAdvisorCategories")]
        [SwaggerOperation(
            Summary = "Creates a new RegionAreaAdvisorCategory",
            Description = "Creates a new RegionAreaAdvisorCategory",
            OperationId = "regionAreaAdvisorCategories.create",
            Tags = new[] { "RegionAreaAdvisorCategoryEndpoints" })
        ]
        public override async Task<ActionResult<CreateRegionAreaAdvisorCategoryResponse>> HandleAsync(
            CreateRegionAreaAdvisorCategoryRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateRegionAreaAdvisorCategoryResponse(request.CorrelationId());

            //var advisor = await _advisorRepository.GetByIdAsync(request.AdvisorId);// parent entity

            var newRegionAreaAdvisorCategory = new RegionAreaAdvisorCategory(
                Guid.NewGuid(),
                request.AdvisorId,
                request.AreaId,
                request.CategoryId,
                request.RegionId
            );


            await _repository.AddAsync(newRegionAreaAdvisorCategory);

            _logger.LogInformation(
                $"RegionAreaAdvisorCategory created  with Id {newRegionAreaAdvisorCategory.RegionAreaAdvisorCategoryId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<RegionAreaAdvisorCategoryDto>(newRegionAreaAdvisorCategory);

            var regionAreaAdvisorCategoryCreatedEvent =
                new RegionAreaAdvisorCategoryCreatedEvent(newRegionAreaAdvisorCategory, "Mongo-History");
            _messagePublisher.Publish(regionAreaAdvisorCategoryCreatedEvent);

            response.RegionAreaAdvisorCategory = dto;


            return Ok(response);
        }
    }
}