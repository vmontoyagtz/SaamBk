using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorCustomer
{
    public class UpdateAdvisorCustomerResponse : BaseResponse
    {
        public UpdateAdvisorCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAdvisorCustomerResponse()
        {
        }

        public AdvisorCustomerDto AdvisorCustomer { get; set; } = new();
    }
}