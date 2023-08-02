using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DiscountCode
{
    public class UpdateDiscountCodeResponse : BaseResponse
    {
        public UpdateDiscountCodeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateDiscountCodeResponse()
        {
        }

        public DiscountCodeDto DiscountCode { get; set; } = new();
    }
}