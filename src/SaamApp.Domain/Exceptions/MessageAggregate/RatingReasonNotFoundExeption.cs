using System;

namespace SaamApp.Domain.Exceptions
{
    public class RatingReasonNotFoundException : Exception
    {
        public RatingReasonNotFoundException(string message) : base(message)
        {
        }

        public RatingReasonNotFoundException(Guid ratingReasonId) : base(
            $"No ratingReason with id {ratingReasonId} found.")
        {
        }
    }
}