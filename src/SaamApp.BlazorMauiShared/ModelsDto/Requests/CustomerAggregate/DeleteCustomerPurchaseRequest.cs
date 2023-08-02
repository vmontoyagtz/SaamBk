using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerPurchase
{
    public class DeleteCustomerPurchaseRequest : BaseRequest
    {
        public Guid CustomerPurchaseId { get; set; }
    }
}