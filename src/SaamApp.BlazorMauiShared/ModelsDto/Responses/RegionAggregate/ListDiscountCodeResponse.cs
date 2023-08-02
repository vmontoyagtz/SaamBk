using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.DiscountCode
{
    public class ListDiscountCodeResponse : BaseResponse
    {
        public ListDiscountCodeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListDiscountCodeResponse()
        {
        }

        public List<DiscountCodeDto> DiscountCodes { get; set; } = new();

        public int Count { get; set; }
    }
}