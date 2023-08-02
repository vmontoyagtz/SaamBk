using System;

namespace SaamApp.Domain.Exceptions
{
    public class AdvisorBankNotFoundException : Exception
    {
        public AdvisorBankNotFoundException(string message) : base(message)
        {
        }

        public AdvisorBankNotFoundException(int rowId) : base($"No advisorBank with id {rowId} found.")
        {
        }
    }
}