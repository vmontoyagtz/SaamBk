using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorCustomer
{
    public class ListAdvisorCustomerResponse : BaseResponse
    {
        public ListAdvisorCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAdvisorCustomerResponse()
        {
        }

        public List<AdvisorCustomerDto> AdvisorCustomers { get; set; } = new();

        public int Count { get; set; }
    }
}