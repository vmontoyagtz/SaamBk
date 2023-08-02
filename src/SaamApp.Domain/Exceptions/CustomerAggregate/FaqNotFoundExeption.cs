using System;

namespace SaamApp.Domain.Exceptions
{
    public class FaqNotFoundException : Exception
    {
        public FaqNotFoundException(string message) : base(message)
        {
        }

        public FaqNotFoundException(Guid faqId) : base($"No faq with id {faqId} found.")
        {
        }
    }
}