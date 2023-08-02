using System;

namespace SaamApp.BlazorMauiShared.Models.AccountStateType
{
    public class DeleteAccountStateTypeRequest : BaseRequest
    {
        public Guid AccountStateTypeId { get; set; }
    }
}