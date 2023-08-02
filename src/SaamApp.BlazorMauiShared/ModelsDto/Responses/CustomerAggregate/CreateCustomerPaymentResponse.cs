using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerPayment
{
    public class CreateCustomerPaymentResponse : BaseResponse
    {
        public CreateCustomerPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCustomerPaymentResponse()
        {
        }

        public CustomerPaymentDto CustomerPayment { get; set; } = new();
    }
}