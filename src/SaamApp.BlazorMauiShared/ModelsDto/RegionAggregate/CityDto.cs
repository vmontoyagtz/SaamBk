using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class CityDto
    {
        public CityDto() { } // AutoMapper required

        public CityDto(Guid cityId, Guid stateId, string cityName, Guid tenantId)
        {
            CityId = Guard.Against.NullOrEmpty(cityId, nameof(cityId));
            StateId = Guard.Against.NullOrEmpty(stateId, nameof(stateId));
            CityName = Guard.Against.NullOrWhiteSpace(cityName, nameof(cityName));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid CityId { get; set; }

        [Required(ErrorMessage = "City Name is required")]
        [MaxLength(100)]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public StateDto State { get; set; }

        [Required(ErrorMessage = "State is required")]
        public Guid StateId { get; set; }

        public List<AddressDto> Addresses { get; set; } = new();
    }
}