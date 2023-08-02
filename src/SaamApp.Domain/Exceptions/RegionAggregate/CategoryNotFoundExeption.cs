using System;

namespace SaamApp.Domain.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException(string message) : base(message)
        {
        }

        public CategoryNotFoundException(Guid categoryId) : base($"No category with id {categoryId} found.")
        {
        }
    }
}