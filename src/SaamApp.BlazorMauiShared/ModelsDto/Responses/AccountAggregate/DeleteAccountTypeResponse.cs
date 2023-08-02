using System;

namespace SaamApp.BlazorMauiShared.Models.AccountType
{
    public class DeleteAccountTypeResponse : BaseResponse
    {
        public DeleteAccountTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAccountTypeResponse()
        {
        }
    }
}