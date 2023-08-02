using System;

namespace SaamApp.BlazorMauiShared.Models.AccountStateType
{
    public class DeleteAccountStateTypeResponse : BaseResponse
    {
        public DeleteAccountStateTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAccountStateTypeResponse()
        {
        }
    }
}