using System;

namespace SaamApp.BlazorMauiShared.Models.GiftCode
{
    public class CreateGiftCodeRequest : BaseRequest
    {
        public Guid RegionId { get; set; }
        public string? GiftCodeName { get; set; }
        public string GiftCodeValue { get; set; }
        public decimal GiftCodeAmount { get; set; }
        public DateTime GiftCodeStartDate { get; set; }
        public DateTime? GiftCodeEndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}