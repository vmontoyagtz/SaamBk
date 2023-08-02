using System;

namespace SaamApp.Domain.Exceptions
{
    public class TaxInformationNotFoundException : Exception
    {
        public TaxInformationNotFoundException(string message) : base(message)
        {
        }

        public TaxInformationNotFoundException(Guid taxInformationId) : base(
            $"No taxInformation with id {taxInformationId} found.")
        {
        }
    }
}