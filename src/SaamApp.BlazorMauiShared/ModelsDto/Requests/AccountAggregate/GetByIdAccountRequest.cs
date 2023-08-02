using System;

namespace SaamApp.BlazorMauiShared.Models.Account
{
    public class GetByIdAccountRequest : BaseRequest
    {
        public Guid AccountId { get; set; }
    }
}