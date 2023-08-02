using System;

namespace SaamApp.Domain.Exceptions
{
    public class TaxpayerTypeNotFoundException : Exception
    {
        public TaxpayerTypeNotFoundException(string message) : base(message)
        {
        }

        public TaxpayerTypeNotFoundException(Guid taxpayerTypeId) : base(
            $"No taxpayerType with id {taxpayerTypeId} found.")
        {
        }
    }
}