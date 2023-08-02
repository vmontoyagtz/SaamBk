using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorCustomerByRelIdsSpec : Specification<AdvisorCustomer>
    {
        public AdvisorCustomerByRelIdsSpec(Guid advisorId, Guid customerId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(advisorCustomer =>
                advisorCustomer.AdvisorId == advisorId && advisorCustomer.CustomerId == customerId).AsNoTracking();
        }
    }
}