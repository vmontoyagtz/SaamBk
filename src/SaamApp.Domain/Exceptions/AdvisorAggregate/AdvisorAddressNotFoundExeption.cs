using System;

namespace SaamApp.Domain.Exceptions
{
    public class AdvisorAddressNotFoundException : Exception
    {
        public AdvisorAddressNotFoundException(string message) : base(message)
        {
        }

        public AdvisorAddressNotFoundException(int rowId) : base($"No advisorAddress with id {rowId} found.")
        {
        }
    }
}