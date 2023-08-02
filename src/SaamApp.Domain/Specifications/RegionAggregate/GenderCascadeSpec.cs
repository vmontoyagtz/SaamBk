using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorWithGenderKeySpec : Specification<Advisor>
    {
        public GetAdvisorWithGenderKeySpec(Guid genderId)
        {
            Guard.Against.NullOrEmpty(genderId, nameof(genderId));
            Query.Where(a => a.GenderId == genderId).AsNoTracking();
        }
    }

    public class GetCustomerWithGenderKeySpec : Specification<Customer>
    {
        public GetCustomerWithGenderKeySpec(Guid genderId)
        {
            Guard.Against.NullOrEmpty(genderId, nameof(genderId));
            Query.Where(c => c.GenderId == genderId).AsNoTracking();
        }
    }
}