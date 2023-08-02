using System;

namespace SaamApp.Domain.Exceptions
{
    public class AdvisorPhoneNumberNotFoundException : Exception
    {
        public AdvisorPhoneNumberNotFoundException(string message) : base(message)
        {
        }

        public AdvisorPhoneNumberNotFoundException(int rowId) : base($"No advisorPhoneNumber with id {rowId} found.")
        {
        }
    }
}