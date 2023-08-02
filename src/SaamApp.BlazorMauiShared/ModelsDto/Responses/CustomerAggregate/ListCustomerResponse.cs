using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Customer
{
    public class ListCustomerResponse : BaseResponse
    {
        public ListCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCustomerResponse()
        {
        }

        public List<CustomerDto> Customers { get; set; } = new();

        public int Count { get; set; }
    }
}