using System;

namespace SaamApp.Domain.Exceptions
{
    public class BusinessUnitTypeNotFoundException : Exception
    {
        public BusinessUnitTypeNotFoundException(string message) : base(message)
        {
        }

        public BusinessUnitTypeNotFoundException(Guid businessUnitTypeId) : base(
            $"No businessUnitType with id {businessUnitTypeId} found.")
        {
        }
    }
}