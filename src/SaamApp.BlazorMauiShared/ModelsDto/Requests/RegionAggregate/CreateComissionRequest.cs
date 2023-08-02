using System;

namespace SaamApp.BlazorMauiShared.Models.Comission
{
    public class CreateComissionRequest : BaseRequest
    {
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public decimal ComissionPercentage { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
        public bool IsDefault { get; set; }
    }
}