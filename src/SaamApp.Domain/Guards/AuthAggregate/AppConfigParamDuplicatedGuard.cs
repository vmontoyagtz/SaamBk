using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class AppConfigParamGuardExtensions
    {
        public static void DuplicateAppConfigParam(this IGuardClause guardClause,
            IEnumerable<AppConfigParam> existingAppConfigParams, AppConfigParam newAppConfigParam, string parameterName)
        {
            if (existingAppConfigParams.Any(a => a.AppConfigParamId == newAppConfigParam.AppConfigParamId))
            {
                throw new DuplicateAppConfigParamException("Cannot add duplicate appConfigParam.", parameterName);
            }
        }
    }
}