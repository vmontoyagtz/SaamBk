using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.GiftCode
{
    public class CreateGiftCodeResponse : BaseResponse
    {
        public CreateGiftCodeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateGiftCodeResponse()
        {
        }

        public GiftCodeDto GiftCode { get; set; } = new();
    }
}