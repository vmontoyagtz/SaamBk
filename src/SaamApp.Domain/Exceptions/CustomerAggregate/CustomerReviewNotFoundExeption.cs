using System;

namespace SaamApp.Domain.Exceptions
{
    public class CustomerReviewNotFoundException : Exception
    {
        public CustomerReviewNotFoundException(string message) : base(message)
        {
        }

        public CustomerReviewNotFoundException(Guid customerReviewId) : base(
            $"No customerReview with id {customerReviewId} found.")
        {
        }
    }
}