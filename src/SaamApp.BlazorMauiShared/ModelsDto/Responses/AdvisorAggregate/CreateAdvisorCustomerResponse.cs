using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorCustomer
{
    public class CreateAdvisorCustomerResponse : BaseResponse
    {
        public CreateAdvisorCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAdvisorCustomerResponse()
        {
        }

        public AdvisorCustomerDto AdvisorCustomer { get; set; } = new();
    }
}