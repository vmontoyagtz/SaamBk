using System;

namespace SaamApp.BlazorMauiShared.Models.PaymentFrequency
{
    public class CreatePaymentFrequencyRequest : BaseRequest
    {
        public string PaymentFrequencyName { get; set; }
        public string PaymentFrequencyValue { get; set; }
        public Guid TenantId { get; set; }
    }
}