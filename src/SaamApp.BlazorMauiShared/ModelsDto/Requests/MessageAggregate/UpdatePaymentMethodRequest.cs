using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PaymentMethod
{
    public class UpdatePaymentMethodRequest : BaseRequest
    {
        public Guid PaymentMethodId { get; set; }
        public string PaymentFrequencyCode { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodDescription { get; set; }
        public Guid TenantId { get; set; }

        public static UpdatePaymentMethodRequest FromDto(PaymentMethodDto paymentMethodDto)
        {
            return new UpdatePaymentMethodRequest
            {
                PaymentMethodId = paymentMethodDto.PaymentMethodId,
                PaymentFrequencyCode = paymentMethodDto.PaymentFrequencyCode,
                PaymentMethodName = paymentMethodDto.PaymentMethodName,
                PaymentMethodDescription = paymentMethodDto.PaymentMethodDescription,
                TenantId = paymentMethodDto.TenantId
            };
        }
    }
}