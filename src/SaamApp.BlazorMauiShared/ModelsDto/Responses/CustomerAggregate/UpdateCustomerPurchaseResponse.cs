using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerPurchase
{
    public class UpdateCustomerPurchaseResponse : BaseResponse
    {
        public UpdateCustomerPurchaseResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCustomerPurchaseResponse()
        {
        }

        public CustomerPurchaseDto CustomerPurchase { get; set; } = new();
    }
}