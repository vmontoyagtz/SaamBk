using System;

namespace SaamApp.Domain.Exceptions
{
    public class BusinessUnitCategoryNotFoundException : Exception
    {
        public BusinessUnitCategoryNotFoundException(string message) : base(message)
        {
        }

        public BusinessUnitCategoryNotFoundException(int rowId) : base(
            $"No businessUnitCategory with id {rowId} found.")
        {
        }
    }
}