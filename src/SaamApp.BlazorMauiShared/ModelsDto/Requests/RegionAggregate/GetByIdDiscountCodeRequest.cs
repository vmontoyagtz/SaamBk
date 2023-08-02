using System;

namespace SaamApp.BlazorMauiShared.Models.DiscountCode
{
    public class GetByIdDiscountCodeRequest : BaseRequest
    {
        public Guid DiscountCodeId { get; set; }
    }
}