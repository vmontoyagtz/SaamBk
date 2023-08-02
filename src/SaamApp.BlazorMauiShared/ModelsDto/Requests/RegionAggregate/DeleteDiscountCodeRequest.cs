using System;

namespace SaamApp.BlazorMauiShared.Models.DiscountCode
{
    public class DeleteDiscountCodeRequest : BaseRequest
    {
        public Guid DiscountCodeId { get; set; }
    }
}