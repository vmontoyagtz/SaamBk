using System;

namespace SaamApp.BlazorMauiShared.Models.GiftCode
{
    public class GetByIdGiftCodeRequest : BaseRequest
    {
        public Guid GiftCodeId { get; set; }
    }
}