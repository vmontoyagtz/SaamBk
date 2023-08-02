using System;

namespace SaamApp.BlazorMauiShared.Models.Account
{
    public class DeleteAccountResponse : BaseResponse
    {
        public DeleteAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAccountResponse()
        {
        }
    }
}