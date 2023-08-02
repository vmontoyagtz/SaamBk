using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerPurchase
{
    public class CreateCustomerPurchaseRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public Guid ReferenceId { get; set; }
        public string ReferenceIdDescription { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal CustomerPurchaseTotal { get; set; }
        public bool IsPositive { get; set; }
        public bool IsNegative { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}