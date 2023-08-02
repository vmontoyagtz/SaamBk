using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerPurchase
{
    public class GetByIdCustomerPurchaseRequest : BaseRequest
    {
        public Guid CustomerPurchaseId { get; set; }
    }
}