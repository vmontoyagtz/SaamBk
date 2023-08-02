using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorCustomer
{
    public class GetByIdAdvisorCustomerResponse : BaseResponse
    {
        public GetByIdAdvisorCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAdvisorCustomerResponse()
        {
        }

        public AdvisorCustomerDto AdvisorCustomer { get; set; } = new();
    }
}