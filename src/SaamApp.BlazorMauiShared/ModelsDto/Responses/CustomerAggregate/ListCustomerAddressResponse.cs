using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAddress
{
    public class ListCustomerAddressResponse : BaseResponse
    {
        public ListCustomerAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCustomerAddressResponse()
        {
        }

        public List<CustomerAddressDto> CustomerAddresses { get; set; } = new();

        public int Count { get; set; }
    }
}