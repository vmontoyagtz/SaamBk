using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CategoryByIdWithIncludesSpec : Specification<Category>, ISingleResultSpecification
    {
        public CategoryByIdWithIncludesSpec(Guid categoryId)
        {
            Guard.Against.NullOrEmpty(categoryId, nameof(categoryId));
            Query.Where(category => category.CategoryId == categoryId)
                .Include(a => a.RegionAreaAdvisorCategories)
                .ThenInclude(a => a.Messages)
                .AsNoTracking();
        }
    }
}