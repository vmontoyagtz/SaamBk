using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PaymentFrequency
{
    public class UpdatePaymentFrequencyRequest : BaseRequest
    {
        public Guid PaymentFrequencyId { get; set; }
        public string PaymentFrequencyName { get; set; }
        public string PaymentFrequencyValue { get; set; }
        public Guid TenantId { get; set; }

        public static UpdatePaymentFrequencyRequest FromDto(PaymentFrequencyDto paymentFrequencyDto)
        {
            return new UpdatePaymentFrequencyRequest
            {
                PaymentFrequencyId = paymentFrequencyDto.PaymentFrequencyId,
                PaymentFrequencyName = paymentFrequencyDto.PaymentFrequencyName,
                PaymentFrequencyValue = paymentFrequencyDto.PaymentFrequencyValue,
                TenantId = paymentFrequencyDto.TenantId
            };
        }
    }
}