using System;

namespace SaamApp.BlazorMauiShared.Models.BankAccount
{
    public class DeleteBankAccountResponse : BaseResponse
    {
        public DeleteBankAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteBankAccountResponse()
        {
        }
    }
}