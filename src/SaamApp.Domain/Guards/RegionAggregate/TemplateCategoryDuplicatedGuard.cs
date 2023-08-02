using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class TemplateCategoryGuardExtensions
    {
        public static void DuplicateTemplateCategory(this IGuardClause guardClause,
            IEnumerable<TemplateCategory> existingTemplateCategories, TemplateCategory newTemplateCategory,
            string parameterName)
        {
            if (existingTemplateCategories.Any(a => a.RowId == newTemplateCategory.RowId))
            {
                throw new DuplicateTemplateCategoryException("Cannot add duplicate templateCategory.", parameterName);
            }
        }
    }
}