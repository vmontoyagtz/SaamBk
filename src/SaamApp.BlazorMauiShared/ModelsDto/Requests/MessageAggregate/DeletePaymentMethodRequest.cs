using System;

namespace SaamApp.BlazorMauiShared.Models.PaymentMethod
{
    public class DeletePaymentMethodRequest : BaseRequest
    {
        public Guid PaymentMethodId { get; set; }
    }
}