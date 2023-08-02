using System;

namespace SaamApp.BlazorMauiShared.Models.SerfinsaPayment
{
    public class CreateSerfinsaPaymentRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
        public Guid DiscountCodeId { get; set; }
        public Guid PrepaidPackageId { get; set; }
        public string SerfinsaPaymentAmount { get; set; }
        public string SerfinsaPaymentTime { get; set; }
        public string SerfinsaPaymentDate { get; set; }
        public string SerfinsaPaymentReferenceNumber { get; set; }
        public string SerfinsaPaymentAuditNo { get; set; }
        public string SerfinsaPaymentTimeMessageType { get; set; }
        public string? SerfinsaPaymentTimeAuthorize { get; set; }
        public string SerfinsaPaymentTimeAnswer { get; set; }
        public string SerfinsaPaymentTimeType { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}