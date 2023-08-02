using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerPurchase
{
    public class ListCustomerPurchaseResponse : BaseResponse
    {
        public ListCustomerPurchaseResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCustomerPurchaseResponse()
        {
        }

        public List<CustomerPurchaseDto> CustomerPurchases { get; set; } = new();

        public int Count { get; set; }
    }
}