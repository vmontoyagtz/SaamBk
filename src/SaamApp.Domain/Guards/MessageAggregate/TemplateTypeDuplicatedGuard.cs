using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class TemplateTypeGuardExtensions
    {
        public static void DuplicateTemplateType(this IGuardClause guardClause,
            IEnumerable<TemplateType> existingTemplateTypes, TemplateType newTemplateType, string parameterName)
        {
            if (existingTemplateTypes.Any(a => a.TemplateTypeId == newTemplateType.TemplateTypeId))
            {
                throw new DuplicateTemplateTypeException("Cannot add duplicate templateType.", parameterName);
            }
        }
    }
}