using System;

namespace SaamApp.Domain.Exceptions
{
    public class BusinessUnitAddressNotFoundException : Exception
    {
        public BusinessUnitAddressNotFoundException(string message) : base(message)
        {
        }

        public BusinessUnitAddressNotFoundException(int rowId) : base($"No businessUnitAddress with id {rowId} found.")
        {
        }
    }
}