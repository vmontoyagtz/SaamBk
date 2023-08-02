using System;

namespace SaamApp.Domain.Exceptions
{
    public class CustomerFeedbackNotFoundException : Exception
    {
        public CustomerFeedbackNotFoundException(string message) : base(message)
        {
        }

        public CustomerFeedbackNotFoundException(Guid feedbackId) : base(
            $"No customerFeedback with id {feedbackId} found.")
        {
        }
    }
}