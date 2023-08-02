using System;

namespace SaamApp.Domain.Exceptions
{
    public class TemplateTypeNotFoundException : Exception
    {
        public TemplateTypeNotFoundException(string message) : base(message)
        {
        }

        public TemplateTypeNotFoundException(Guid templateTypeId) : base(
            $"No templateType with id {templateTypeId} found.")
        {
        }
    }
}