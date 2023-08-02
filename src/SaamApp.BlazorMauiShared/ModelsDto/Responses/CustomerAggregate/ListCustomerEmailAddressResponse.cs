using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerEmailAddress
{
    public class ListCustomerEmailAddressResponse : BaseResponse
    {
        public ListCustomerEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCustomerEmailAddressResponse()
        {
        }

        public List<CustomerEmailAddressDto> CustomerEmailAddresses { get; set; } = new();

        public int Count { get; set; }
    }
}