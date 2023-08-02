using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class BusinessUnitTypeDto
    {
        public BusinessUnitTypeDto() { } // AutoMapper required

        public BusinessUnitTypeDto(Guid businessUnitTypeId, string businessUnitTypeName,
            string? businessUnitTypeDescription)
        {
            BusinessUnitTypeId = Guard.Against.NullOrEmpty(businessUnitTypeId, nameof(businessUnitTypeId));
            BusinessUnitTypeName = Guard.Against.NullOrWhiteSpace(businessUnitTypeName, nameof(businessUnitTypeName));
            BusinessUnitTypeDescription = businessUnitTypeDescription;
        }

        public Guid BusinessUnitTypeId { get; set; }

        [Required(ErrorMessage = "Business Unit Type Name is required")]
        [MaxLength(100)]
        public string BusinessUnitTypeName { get; set; }

        [MaxLength(100)] public string? BusinessUnitTypeDescription { get; set; }
    }
}