using System;

namespace SaamApp.Domain.Exceptions
{
    public class EmployeeEmailAddressNotFoundException : Exception
    {
        public EmployeeEmailAddressNotFoundException(string message) : base(message)
        {
        }

        public EmployeeEmailAddressNotFoundException(int rowId) : base(
            $"No employeeEmailAddress with id {rowId} found.")
        {
        }
    }
}