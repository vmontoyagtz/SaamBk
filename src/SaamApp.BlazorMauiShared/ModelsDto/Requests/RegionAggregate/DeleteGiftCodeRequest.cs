using System;

namespace SaamApp.BlazorMauiShared.Models.GiftCode
{
    public class DeleteGiftCodeRequest : BaseRequest
    {
        public Guid GiftCodeId { get; set; }
    }
}