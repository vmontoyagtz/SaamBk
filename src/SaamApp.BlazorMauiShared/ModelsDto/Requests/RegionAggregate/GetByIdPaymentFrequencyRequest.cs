using System;

namespace SaamApp.BlazorMauiShared.Models.PaymentFrequency
{
    public class GetByIdPaymentFrequencyRequest : BaseRequest
    {
        public Guid PaymentFrequencyId { get; set; }
    }
}