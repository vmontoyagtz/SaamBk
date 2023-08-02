using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerPayment
{
    public class GetByIdCustomerPaymentResponse : BaseResponse
    {
        public GetByIdCustomerPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCustomerPaymentResponse()
        {
        }

        public CustomerPaymentDto CustomerPayment { get; set; } = new();
    }
}