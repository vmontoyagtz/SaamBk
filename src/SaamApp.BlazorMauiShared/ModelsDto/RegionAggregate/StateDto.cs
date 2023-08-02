using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class StateDto
    {
        public StateDto() { } // AutoMapper required

        public StateDto(Guid stateId, Guid countryId, string stateName, Guid tenantId)
        {
            StateId = Guard.Against.NullOrEmpty(stateId, nameof(stateId));
            CountryId = Guard.Against.NullOrEmpty(countryId, nameof(countryId));
            StateName = Guard.Against.NullOrWhiteSpace(stateName, nameof(stateName));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid StateId { get; set; }

        [Required(ErrorMessage = "State Name is required")]
        [MaxLength(100)]
        public string StateName { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public CountryDto Country { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public Guid CountryId { get; set; }

        public List<AddressDto> Addresses { get; set; } = new();
        public List<CityDto> Cities { get; set; } = new();
    }
}