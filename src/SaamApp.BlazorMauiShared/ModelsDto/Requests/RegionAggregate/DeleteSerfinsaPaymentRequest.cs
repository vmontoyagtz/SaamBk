using System;

namespace SaamApp.BlazorMauiShared.Models.SerfinsaPayment
{
    public class DeleteSerfinsaPaymentRequest : BaseRequest
    {
        public Guid SerfinsaPaymentId { get; set; }
    }
}