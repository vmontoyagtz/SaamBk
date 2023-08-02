using System;

namespace SaamApp.Domain.Exceptions
{
    public class BusinessUnitNotFoundException : Exception
    {
        public BusinessUnitNotFoundException(string message) : base(message)
        {
        }

        public BusinessUnitNotFoundException(Guid businessUnitId) : base(
            $"No businessUnit with id {businessUnitId} found.")
        {
        }
    }
}