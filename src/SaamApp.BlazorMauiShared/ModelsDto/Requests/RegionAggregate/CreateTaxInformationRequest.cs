using System;

namespace SaamApp.BlazorMauiShared.Models.TaxInformation
{
    public class CreateTaxInformationRequest : BaseRequest
    {
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
    }
}