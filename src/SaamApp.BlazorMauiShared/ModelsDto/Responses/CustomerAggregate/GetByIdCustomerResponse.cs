using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Customer
{
    public class GetByIdCustomerResponse : BaseResponse
    {
        public GetByIdCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCustomerResponse()
        {
        }

        public CustomerDto Customer { get; set; } = new();
    }
}