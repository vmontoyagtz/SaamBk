using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AdvisorApplicantGuardExtensions
    {
        public static void DuplicateAdvisorApplicant(this IGuardClause guardClause,
            IEnumerable<AdvisorApplicant> existingAdvisorApplicants, AdvisorApplicant newAdvisorApplicant,
            string parameterName)
        {
            if (existingAdvisorApplicants.Any(a => a.AdvisorApplicantId == newAdvisorApplicant.AdvisorApplicantId))
            {
                throw new DuplicateAdvisorApplicantException("Cannot add duplicate advisorApplicant.", parameterName);
            }
        }
    }
}