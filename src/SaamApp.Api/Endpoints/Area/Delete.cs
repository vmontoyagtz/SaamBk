using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Area;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AreaEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAreaRequest>.WithActionResult<
        DeleteAreaResponse>
    {
        private readonly IRepository<Area> _areaReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<RegionAreaAdvisorCategory> _regionAreaAdvisorCategoryRepository;
        private readonly IRepository<Area> _repository;

        public Delete(IRepository<Area> AreaRepository, IRepository<Area> AreaReadRepository,
            IRepository<RegionAreaAdvisorCategory> regionAreaAdvisorCategoryRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AreaRepository;
            _areaReadRepository = AreaReadRepository;
            _regionAreaAdvisorCategoryRepository = regionAreaAdvisorCategoryRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/areas/{AreaId}")]
        [SwaggerOperation(
            Summary = "Deletes an Area",
            Description = "Deletes an Area",
            OperationId = "areas.delete",
            Tags = new[] { "AreaEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAreaResponse>> HandleAsync(
            [FromRoute] DeleteAreaRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAreaResponse(request.CorrelationId());

            var area = await _areaReadRepository.GetByIdAsync(request.AreaId);

            if (area == null)
            {
                return NotFound();
            }

            var regionAreaAdvisorCategorySpec = new GetRegionAreaAdvisorCategoryWithAreaKeySpec(area.AreaId);
            var regionAreaAdvisorCategories =
                await _regionAreaAdvisorCategoryRepository.ListAsync(regionAreaAdvisorCategorySpec);
            await _regionAreaAdvisorCategoryRepository
                .DeleteRangeAsync(regionAreaAdvisorCategories); // you could use soft delete with IsDeleted = true

            var areaDeletedEvent = new AreaDeletedEvent(area, "Mongo-History");
            _messagePublisher.Publish(areaDeletedEvent);

            await _repository.DeleteAsync(area);

            return Ok(response);
        }
    }
}