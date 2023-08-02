using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class TemplateGuardExtensions
    {
        public static void DuplicateTemplate(this IGuardClause guardClause, IEnumerable<Template> existingTemplates,
            Template newTemplate, string parameterName)
        {
            if (existingTemplates.Any(a => a.TemplateId == newTemplate.TemplateId))
            {
                throw new DuplicateTemplateException("Cannot add duplicate template.", parameterName);
            }
        }
    }
}