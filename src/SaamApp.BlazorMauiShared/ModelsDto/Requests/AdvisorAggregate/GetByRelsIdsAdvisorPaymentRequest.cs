using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPayment
{
    public class GetByRelsIdsAdvisorPaymentRequest : BaseRequest
    {
        public string AdvisorPaymentDescription { get; set; }
        public decimal AdvisorPaymentsAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid BankAccountId { get; set; }
        public Guid PaymentMethodId { get; set; }
    }
}