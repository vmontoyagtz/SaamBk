using System;

namespace SaamApp.Domain.Exceptions
{
    public class BusinessUnitEmailAddressNotFoundException : Exception
    {
        public BusinessUnitEmailAddressNotFoundException(string message) : base(message)
        {
        }

        public BusinessUnitEmailAddressNotFoundException(int rowId) : base(
            $"No businessUnitEmailAddress with id {rowId} found.")
        {
        }
    }
}