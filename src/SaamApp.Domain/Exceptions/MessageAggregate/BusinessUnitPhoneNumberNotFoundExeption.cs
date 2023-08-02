using System;

namespace SaamApp.Domain.Exceptions
{
    public class BusinessUnitPhoneNumberNotFoundException : Exception
    {
        public BusinessUnitPhoneNumberNotFoundException(string message) : base(message)
        {
        }

        public BusinessUnitPhoneNumberNotFoundException(int rowId) : base(
            $"No businessUnitPhoneNumber with id {rowId} found.")
        {
        }
    }
}