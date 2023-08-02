using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.RegionAreaAdvisorCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.RegionAreaAdvisorCategoryEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateRegionAreaAdvisorCategoryRequest>.WithActionResult<
        UpdateRegionAreaAdvisorCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<RegionAreaAdvisorCategory> _repository;

        public Update(
            IRepository<RegionAreaAdvisorCategory> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/regionAreaAdvisorCategories")]
        [SwaggerOperation(
            Summary = "Updates a RegionAreaAdvisorCategory",
            Description = "Updates a RegionAreaAdvisorCategory",
            OperationId = "regionAreaAdvisorCategories.update",
            Tags = new[] { "RegionAreaAdvisorCategoryEndpoints" })
        ]
        public override async Task<ActionResult<UpdateRegionAreaAdvisorCategoryResponse>> HandleAsync(
            UpdateRegionAreaAdvisorCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateRegionAreaAdvisorCategoryResponse(request.CorrelationId());

            var raaceaacgaacToUpdate = _mapper.Map<RegionAreaAdvisorCategory>(request);

            var regionAreaAdvisorCategoryToUpdateTest =
                await _repository.GetByIdAsync(request.RegionAreaAdvisorCategoryId);
            if (regionAreaAdvisorCategoryToUpdateTest is null)
            {
                return NotFound();
            }

            raaceaacgaacToUpdate.UpdateAreaForRegionAreaAdvisorCategory(request.AreaId);
            raaceaacgaacToUpdate.UpdateCategoryForRegionAreaAdvisorCategory(request.CategoryId);
            raaceaacgaacToUpdate.UpdateRegionForRegionAreaAdvisorCategory(request.RegionId);
            raaceaacgaacToUpdate.UpdateAdvisorForRegionAreaAdvisorCategory(request.AdvisorId);
            await _repository.UpdateAsync(raaceaacgaacToUpdate);

            var regionAreaAdvisorCategoryUpdatedEvent =
                new RegionAreaAdvisorCategoryUpdatedEvent(raaceaacgaacToUpdate, "Mongo-History");
            _messagePublisher.Publish(regionAreaAdvisorCategoryUpdatedEvent);

            var dto = _mapper.Map<RegionAreaAdvisorCategoryDto>(raaceaacgaacToUpdate);
            response.RegionAreaAdvisorCategory = dto;

            return Ok(response);
        }
    }
}