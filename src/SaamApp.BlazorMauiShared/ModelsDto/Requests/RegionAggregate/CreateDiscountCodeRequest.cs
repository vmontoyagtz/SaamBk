using System;

namespace SaamApp.BlazorMauiShared.Models.DiscountCode
{
    public class CreateDiscountCodeRequest : BaseRequest
    {
        public Guid RegionId { get; set; }
        public string DiscountCodeName { get; set; }
        public string DiscountCodeValue { get; set; }
        public decimal DiscountCodePercentage { get; set; }
        public DateTime DiscountCodeStartDate { get; set; }
        public DateTime? DiscountCodeEndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}