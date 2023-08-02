using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class TaxpayerTypeDto
    {
        public TaxpayerTypeDto() { } // AutoMapper required

        public TaxpayerTypeDto(Guid taxpayerTypeId, string taxpayerTypeName, Guid tenantId)
        {
            TaxpayerTypeId = Guard.Against.NullOrEmpty(taxpayerTypeId, nameof(taxpayerTypeId));
            TaxpayerTypeName = Guard.Against.NullOrWhiteSpace(taxpayerTypeName, nameof(taxpayerTypeName));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid TaxpayerTypeId { get; set; }

        [Required(ErrorMessage = "Taxpayer Type Name is required")]
        [MaxLength(100)]
        public string TaxpayerTypeName { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<TaxInformationDto> TaxInformations { get; set; } = new();
    }
}