using System;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackage
{
    public class CreatePrepaidPackageRequest : BaseRequest
    {
        public Guid RegionId { get; set; }
        public string PrepaidPackageName { get; set; }
        public decimal PrepaidPackagePrice { get; set; }
        public bool? PrepaidPackageIsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}