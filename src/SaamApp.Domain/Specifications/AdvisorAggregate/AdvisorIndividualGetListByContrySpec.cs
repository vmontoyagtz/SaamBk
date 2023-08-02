using System;
using System.Linq;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorIndividualGetListByContrySpec : Specification<Advisor>
    {
        public AdvisorIndividualGetListByContrySpec(Guid countryId)
        {
            Guard.Against.NullOrEmpty(countryId, nameof(countryId));

            Query.Where(advisor => advisor.IsNaturalPerson == true)
                .Include(c => c.AdvisorAddresses.Where(aa => aa.Address.Country.CountryId == countryId))
                .AsNoTracking();
        }
    }
}