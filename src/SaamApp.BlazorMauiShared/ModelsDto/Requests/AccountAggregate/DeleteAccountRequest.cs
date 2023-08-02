using System;

namespace SaamApp.BlazorMauiShared.Models.Account
{
    public class DeleteAccountRequest : BaseRequest
    {
        public Guid AccountId { get; set; }
    }
}