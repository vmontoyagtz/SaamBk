using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class CategoryGuardExtensions
    {
        public static void DuplicateCategory(this IGuardClause guardClause, IEnumerable<Category> existingCategories,
            Category newCategory, string parameterName)
        {
            if (existingCategories.Any(a => a.CategoryId == newCategory.CategoryId))
            {
                throw new DuplicateCategoryException("Cannot add duplicate category.", parameterName);
            }
        }
    }
}