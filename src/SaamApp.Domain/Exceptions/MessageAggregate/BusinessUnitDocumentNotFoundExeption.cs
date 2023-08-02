using System;

namespace SaamApp.Domain.Exceptions
{
    public class BusinessUnitDocumentNotFoundException : Exception
    {
        public BusinessUnitDocumentNotFoundException(string message) : base(message)
        {
        }

        public BusinessUnitDocumentNotFoundException(int rowId) : base(
            $"No businessUnitDocument with id {rowId} found.")
        {
        }
    }
}