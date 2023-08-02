using System;

namespace SaamApp.BlazorMauiShared.Models.PaymentMethod
{
    public class GetByIdPaymentMethodRequest : BaseRequest
    {
        public Guid PaymentMethodId { get; set; }
    }
}