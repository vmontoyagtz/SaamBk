using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Customer
{
    public class CreateCustomerResponse : BaseResponse
    {
        public CreateCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCustomerResponse()
        {
        }

        public CustomerDto Customer { get; set; } = new();
    }
}