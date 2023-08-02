using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPayment
{
    public class CreateAdvisorPaymentRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid BankAccountId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public string AdvisorPaymentDescription { get; set; }
        public decimal AdvisorPaymentsAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}