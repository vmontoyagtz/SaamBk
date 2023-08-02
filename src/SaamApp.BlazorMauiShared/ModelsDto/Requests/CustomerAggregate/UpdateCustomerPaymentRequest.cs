using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerPayment
{
    public class UpdateCustomerPaymentRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid SerfinsaPaymentId { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateCustomerPaymentRequest FromDto(CustomerPaymentDto customerPaymentDto)
        {
            return new UpdateCustomerPaymentRequest
            {
                RowId = customerPaymentDto.RowId,
                PaymentMethodId = customerPaymentDto.PaymentMethodId,
                SerfinsaPaymentId = customerPaymentDto.SerfinsaPaymentId,
                TenantId = customerPaymentDto.TenantId
            };
        }
    }
}