using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAccount
{
    public class ListCustomerAccountResponse : BaseResponse
    {
        public ListCustomerAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCustomerAccountResponse()
        {
        }

        public List<CustomerAccountDto> CustomerAccounts { get; set; } = new();

        public int Count { get; set; }
    }
}