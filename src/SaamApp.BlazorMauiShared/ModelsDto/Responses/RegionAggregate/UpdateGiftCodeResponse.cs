using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.GiftCode
{
    public class UpdateGiftCodeResponse : BaseResponse
    {
        public UpdateGiftCodeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateGiftCodeResponse()
        {
        }

        public GiftCodeDto GiftCode { get; set; } = new();
    }
}