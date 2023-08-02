using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Customer
{
    public class UpdateCustomerResponse : BaseResponse
    {
        public UpdateCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCustomerResponse()
        {
        }

        public CustomerDto Customer { get; set; } = new();
    }
}