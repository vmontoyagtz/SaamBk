using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerPurchase
{
    public class GetByIdCustomerPurchaseResponse : BaseResponse
    {
        public GetByIdCustomerPurchaseResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCustomerPurchaseResponse()
        {
        }

        public CustomerPurchaseDto CustomerPurchase { get; set; } = new();
    }
}