using System;

namespace SaamApp.Domain.Exceptions
{
    public class AdvisorEmailAddressNotFoundException : Exception
    {
        public AdvisorEmailAddressNotFoundException(string message) : base(message)
        {
        }

        public AdvisorEmailAddressNotFoundException(int rowId) : base($"No advisorEmailAddress with id {rowId} found.")
        {
        }
    }
}