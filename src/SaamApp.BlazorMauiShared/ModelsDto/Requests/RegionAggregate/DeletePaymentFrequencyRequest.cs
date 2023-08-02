using System;

namespace SaamApp.BlazorMauiShared.Models.PaymentFrequency
{
    public class DeletePaymentFrequencyRequest : BaseRequest
    {
        public Guid PaymentFrequencyId { get; set; }
    }
}