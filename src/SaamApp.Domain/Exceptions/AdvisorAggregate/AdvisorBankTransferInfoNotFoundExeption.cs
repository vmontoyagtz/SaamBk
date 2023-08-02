using System;

namespace SaamApp.Domain.Exceptions
{
    public class AdvisorBankTransferInfoNotFoundException : Exception
    {
        public AdvisorBankTransferInfoNotFoundException(string message) : base(message)
        {
        }

        public AdvisorBankTransferInfoNotFoundException(Guid advisorBankTransferInfoId) : base(
            $"No advisorBankTransferInfo with id {advisorBankTransferInfoId} found.")
        {
        }
    }
}