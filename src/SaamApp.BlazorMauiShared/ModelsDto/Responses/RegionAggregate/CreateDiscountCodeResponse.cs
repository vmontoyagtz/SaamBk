using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DiscountCode
{
    public class CreateDiscountCodeResponse : BaseResponse
    {
        public CreateDiscountCodeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateDiscountCodeResponse()
        {
        }

        public DiscountCodeDto DiscountCode { get; set; } = new();
    }
}