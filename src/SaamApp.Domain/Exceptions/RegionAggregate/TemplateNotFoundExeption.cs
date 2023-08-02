using System;

namespace SaamApp.Domain.Exceptions
{
    public class TemplateNotFoundException : Exception
    {
        public TemplateNotFoundException(string message) : base(message)
        {
        }

        public TemplateNotFoundException(Guid templateId) : base($"No template with id {templateId} found.")
        {
        }
    }
}