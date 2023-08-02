using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerPayment
{
    public class GetByRelsIdsCustomerPaymentRequest : BaseRequest
    {
        public Guid PaymentMethodId { get; set; }
        public Guid SerfinsaPaymentId { get; set; }
        public Guid TenantId { get; set; }
    }
}