using System;

namespace SaamApp.BlazorMauiShared.Models.Product
{
    public class CreateProductRequest : BaseRequest
    {
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public bool ProductIsActive { get; set; }
        public int ProductMinimumCharacters { get; set; }
        public int ProductMinimumCallMinutes { get; set; }
        public decimal ProductChargeRatePerCharacter { get; set; }
        public decimal ProductChargeRateCallPerSecond { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}