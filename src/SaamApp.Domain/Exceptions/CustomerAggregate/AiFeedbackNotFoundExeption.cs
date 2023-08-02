using System;

namespace SaamApp.Domain.Exceptions
{
    public class AiFeedbackNotFoundException : Exception
    {
        public AiFeedbackNotFoundException(string message) : base(message)
        {
        }

        public AiFeedbackNotFoundException(Guid aiFeedbackId) : base($"No aiFeedback with id {aiFeedbackId} found.")
        {
        }
    }
}