using System;

namespace SaamApp.Domain.Exceptions
{
    public class TemplateCategoryNotFoundException : Exception
    {
        public TemplateCategoryNotFoundException(string message) : base(message)
        {
        }

        public TemplateCategoryNotFoundException(int rowId) : base($"No templateCategory with id {rowId} found.")
        {
        }
    }
}