using System;

namespace SaamApp.Domain.Exceptions
{
    public class EmployeeAddressNotFoundException : Exception
    {
        public EmployeeAddressNotFoundException(string message) : base(message)
        {
        }

        public EmployeeAddressNotFoundException(int rowId) : base($"No employeeAddress with id {rowId} found.")
        {
        }
    }
}