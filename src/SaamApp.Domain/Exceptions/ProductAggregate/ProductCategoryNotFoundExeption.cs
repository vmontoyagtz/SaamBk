using System;

namespace SaamApp.Domain.Exceptions
{
    public class ProductCategoryNotFoundException : Exception
    {
        public ProductCategoryNotFoundException(string message) : base(message)
        {
        }

        public ProductCategoryNotFoundException(int rowId) : base($"No productCategory with id {rowId} found.")
        {
        }
    }
}