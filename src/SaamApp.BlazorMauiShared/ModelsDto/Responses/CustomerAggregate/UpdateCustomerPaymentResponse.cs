using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerPayment
{
    public class UpdateCustomerPaymentResponse : BaseResponse
    {
        public UpdateCustomerPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCustomerPaymentResponse()
        {
        }

        public CustomerPaymentDto CustomerPayment { get; set; } = new();
    }
}