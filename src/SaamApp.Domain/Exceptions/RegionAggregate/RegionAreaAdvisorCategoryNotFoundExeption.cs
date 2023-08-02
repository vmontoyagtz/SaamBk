using System;

namespace SaamApp.Domain.Exceptions
{
    public class RegionAreaAdvisorCategoryNotFoundException : Exception
    {
        public RegionAreaAdvisorCategoryNotFoundException(string message) : base(message)
        {
        }

        public RegionAreaAdvisorCategoryNotFoundException(Guid regionAreaAdvisorCategoryId) : base(
            $"No regionAreaAdvisorCategory with id {regionAreaAdvisorCategoryId} found.")
        {
        }
    }
}