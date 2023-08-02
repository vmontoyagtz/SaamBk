using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerPurchase
{
    public class CreateCustomerPurchaseResponse : BaseResponse
    {
        public CreateCustomerPurchaseResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCustomerPurchaseResponse()
        {
        }

        public CustomerPurchaseDto CustomerPurchase { get; set; } = new();
    }
}