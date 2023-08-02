using System;

namespace SaamApp.BlazorMauiShared.Models.PaymentMethod
{
    public class CreatePaymentMethodRequest : BaseRequest
    {
        public string PaymentFrequencyCode { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodDescription { get; set; }
        public Guid TenantId { get; set; }
    }
}