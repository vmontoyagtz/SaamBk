using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AppConfigParamByIdWithIncludesSpec : Specification<AppConfigParam>, ISingleResultSpecification
    {
        public AppConfigParamByIdWithIncludesSpec(Guid appConfigParamId)
        {
            Guard.Against.NullOrEmpty(appConfigParamId, nameof(appConfigParamId));
            Query.Where(appConfigParam => appConfigParam.AppConfigParamId == appConfigParamId)
                .AsNoTracking();
        }
    }
}