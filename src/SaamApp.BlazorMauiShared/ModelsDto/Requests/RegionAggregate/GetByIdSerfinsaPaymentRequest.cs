using System;

namespace SaamApp.BlazorMauiShared.Models.SerfinsaPayment
{
    public class GetByIdSerfinsaPaymentRequest : BaseRequest
    {
        public Guid SerfinsaPaymentId { get; set; }
    }
}