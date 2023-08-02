using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CategoryGetListSpec : Specification<Category>
    {
        public CategoryGetListSpec()
        {
            Query.OrderBy(category => category.CategoryId)
                .AsNoTracking();
        }
    }
}