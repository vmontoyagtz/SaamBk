using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ProductCategoryGetListSpec : Specification<ProductCategory>
    {
        public ProductCategoryGetListSpec()
        {
            Query.OrderBy(productCategory => productCategory.RowId)
                .AsNoTracking();
        }
    }
}