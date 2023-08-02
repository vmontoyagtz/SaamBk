using System;

namespace SaamApp.Domain.Exceptions
{
    public class PrepaidPackageNotFoundException : Exception
    {
        public PrepaidPackageNotFoundException(string message) : base(message)
        {
        }

        public PrepaidPackageNotFoundException(Guid prepaidPackageId) : base(
            $"No prepaidPackage with id {prepaidPackageId} found.")
        {
        }
    }
}