using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerPayment
{
    public class ListCustomerPaymentResponse : BaseResponse
    {
        public ListCustomerPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCustomerPaymentResponse()
        {
        }

        public List<CustomerPaymentDto> CustomerPayments { get; set; } = new();

        public int Count { get; set; }
    }
}