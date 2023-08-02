using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class RegionDto
    {
        public Guid RegionId { get; set; }

        [Required(ErrorMessage = "Region Name is required")]
        [MaxLength(100)]
        public string RegionName { get; set; }

        [Required(ErrorMessage = "Region Code is required")]
        [MaxLength(100)]
        public string RegionCode { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<AddressDto> Addresses { get; set; } = new();
        public List<CountryDto> Countries { get; set; } = new();
        public List<DiscountCodeDto> DiscountCodes { get; set; } = new();
        public List<GiftCodeDto> GiftCodes { get; set; } = new();
        public List<PrepaidPackageDto> PrepaidPackages { get; set; } = new();
        public List<RegionAreaAdvisorCategoryDto> RegionAreaAdvisorCategories { get; set; } = new();
    }
}