using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AdvisorBankTransferInfoGuardExtensions
    {
        public static void DuplicateAdvisorBankTransferInfo(this IGuardClause guardClause,
            IEnumerable<AdvisorBankTransferInfo> existingAdvisorBankTransferInfoes,
            AdvisorBankTransferInfo newAdvisorBankTransferInfo, string parameterName)
        {
            if (existingAdvisorBankTransferInfoes.Any(a =>
                    a.AdvisorBankTransferInfoId == newAdvisorBankTransferInfo.AdvisorBankTransferInfoId))
            {
                throw new DuplicateAdvisorBankTransferInfoException("Cannot add duplicate advisorBankTransferInfo.",
                    parameterName);
            }
        }
    }
}