using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DiscountCode
{
    public class GetByIdDiscountCodeResponse : BaseResponse
    {
        public GetByIdDiscountCodeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdDiscountCodeResponse()
        {
        }

        public DiscountCodeDto DiscountCode { get; set; } = new();
    }
}