using System;

namespace SaamApp.BlazorMauiShared.Models.Bank
{
    public class DeleteBankResponse : BaseResponse
    {
        public DeleteBankResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteBankResponse()
        {
        }
    }
}