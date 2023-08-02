using System;

namespace SaamApp.Domain.Exceptions
{
    public class AdvisorRatingNotFoundException : Exception
    {
        public AdvisorRatingNotFoundException(string message) : base(message)
        {
        }

        public AdvisorRatingNotFoundException(int rowId) : base($"No advisorRating with id {rowId} found.")
        {
        }
    }
}