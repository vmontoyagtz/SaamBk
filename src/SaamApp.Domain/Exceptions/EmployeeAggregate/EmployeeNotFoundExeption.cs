using System;

namespace SaamApp.Domain.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(string message) : base(message)
        {
        }

        public EmployeeNotFoundException(Guid employeeId) : base($"No employee with id {employeeId} found.")
        {
        }
    }
}