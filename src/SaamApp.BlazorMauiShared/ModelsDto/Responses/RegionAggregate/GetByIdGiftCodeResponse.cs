using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.GiftCode
{
    public class GetByIdGiftCodeResponse : BaseResponse
    {
        public GetByIdGiftCodeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdGiftCodeResponse()
        {
        }

        public GiftCodeDto GiftCode { get; set; } = new();
    }
}