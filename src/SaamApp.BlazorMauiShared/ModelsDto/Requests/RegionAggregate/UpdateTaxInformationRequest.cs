using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TaxInformation
{
    public class UpdateTaxInformationRequest : BaseRequest
    {
        public Guid TaxInformationId { get; set; }
        public Guid BusinessUnitId { get; set; }
        public Guid TaxpayerTypeId { get; set; }
        public Guid BusinessTypeId { get; set; }
        public string? TaxInformationBusinessName { get; set; }
        public string? TaxInformationCommercialName { get; set; }
        public Guid TaxInformationRegistrationId { get; set; }
        public string? TaxInformationBusinessIndustry { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateTaxInformationRequest FromDto(TaxInformationDto taxInformationDto)
        {
            return new UpdateTaxInformationRequest
            {
                TaxInformationId = taxInformationDto.TaxInformationId,
                BusinessUnitId = taxInformationDto.BusinessUnitId,
                TaxpayerTypeId = taxInformationDto.TaxpayerTypeId,
                BusinessTypeId = taxInformationDto.BusinessTypeId,
                TaxInformationBusinessName = taxInformationDto.TaxInformationBusinessName,
                TaxInformationCommercialName = taxInformationDto.TaxInformationCommercialName,
                TaxInformationRegistrationId = taxInformationDto.TaxInformationRegistrationId,
                TaxInformationBusinessIndustry = taxInformationDto.TaxInformationBusinessIndustry,
                CreatedAt = taxInformationDto.CreatedAt,
                CreatedBy = taxInformationDto.CreatedBy,
                UpdatedAt = taxInformationDto.UpdatedAt,
                UpdatedBy = taxInformationDto.UpdatedBy,
                IsDeleted = taxInformationDto.IsDeleted,
                TenantId = taxInformationDto.TenantId
            };
        }
    }
}