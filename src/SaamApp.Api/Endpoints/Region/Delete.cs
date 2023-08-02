using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Region;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.RegionEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteRegionRequest>.WithActionResult<
        DeleteRegionResponse>
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<DiscountCode> _discountCodeRepository;
        private readonly IRepository<GiftCode> _giftCodeRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PrepaidPackage> _prepaidPackageRepository;
        private readonly IRepository<RegionAreaAdvisorCategory> _regionAreaAdvisorCategoryRepository;
        private readonly IRepository<Region> _regionReadRepository;
        private readonly IRepository<Region> _repository;

        public Delete(IRepository<Region> RegionRepository, IRepository<Region> RegionReadRepository,
            IRepository<Address> addressRepository,
            IRepository<Country> countryRepository,
            IRepository<DiscountCode> discountCodeRepository,
            IRepository<GiftCode> giftCodeRepository,
            IRepository<PrepaidPackage> prepaidPackageRepository,
            IRepository<RegionAreaAdvisorCategory> regionAreaAdvisorCategoryRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = RegionRepository;
            _regionReadRepository = RegionReadRepository;
            _addressRepository = addressRepository;
            _countryRepository = countryRepository;
            _discountCodeRepository = discountCodeRepository;
            _giftCodeRepository = giftCodeRepository;
            _prepaidPackageRepository = prepaidPackageRepository;
            _regionAreaAdvisorCategoryRepository = regionAreaAdvisorCategoryRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/regions/{RegionId}")]
        [SwaggerOperation(
            Summary = "Deletes an Region",
            Description = "Deletes an Region",
            OperationId = "regions.delete",
            Tags = new[] { "RegionEndpoints" })
        ]
        public override async Task<ActionResult<DeleteRegionResponse>> HandleAsync(
            [FromRoute] DeleteRegionRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteRegionResponse(request.CorrelationId());

            var region = await _regionReadRepository.GetByIdAsync(request.RegionId);

            if (region == null)
            {
                return NotFound();
            }

            var addressSpec = new GetAddressWithRegionKeySpec(region.RegionId);
            var addresses = await _addressRepository.ListAsync(addressSpec);
            await _addressRepository.DeleteRangeAsync(addresses); // you could use soft delete with IsDeleted = true
            var countrySpec = new GetCountryWithRegionKeySpec(region.RegionId);
            var countries = await _countryRepository.ListAsync(countrySpec);
            await _countryRepository.DeleteRangeAsync(countries); // you could use soft delete with IsDeleted = true
            var discountCodeSpec = new GetDiscountCodeWithRegionKeySpec(region.RegionId);
            var discountCodes = await _discountCodeRepository.ListAsync(discountCodeSpec);
            await _discountCodeRepository
                .DeleteRangeAsync(discountCodes); // you could use soft delete with IsDeleted = true
            var giftCodeSpec = new GetGiftCodeWithRegionKeySpec(region.RegionId);
            var giftCodes = await _giftCodeRepository.ListAsync(giftCodeSpec);
            await _giftCodeRepository.DeleteRangeAsync(giftCodes); // you could use soft delete with IsDeleted = true
            var prepaidPackageSpec = new GetPrepaidPackageWithRegionKeySpec(region.RegionId);
            var prepaidPackages = await _prepaidPackageRepository.ListAsync(prepaidPackageSpec);
            await _prepaidPackageRepository
                .DeleteRangeAsync(prepaidPackages); // you could use soft delete with IsDeleted = true
            var regionAreaAdvisorCategorySpec = new GetRegionAreaAdvisorCategoryWithRegionKeySpec(region.RegionId);
            var regionAreaAdvisorCategories =
                await _regionAreaAdvisorCategoryRepository.ListAsync(regionAreaAdvisorCategorySpec);
            await _regionAreaAdvisorCategoryRepository
                .DeleteRangeAsync(regionAreaAdvisorCategories); // you could use soft delete with IsDeleted = true

            var regionDeletedEvent = new RegionDeletedEvent(region, "Mongo-History");
            _messagePublisher.Publish(regionDeletedEvent);

            await _repository.DeleteAsync(region);

            return Ok(response);
        }
    }
}