using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.GiftCode
{
    public class ListGiftCodeResponse : BaseResponse
    {
        public ListGiftCodeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListGiftCodeResponse()
        {
        }

        public List<GiftCodeDto> GiftCodes { get; set; } = new();

        public int Count { get; set; }
    }
}