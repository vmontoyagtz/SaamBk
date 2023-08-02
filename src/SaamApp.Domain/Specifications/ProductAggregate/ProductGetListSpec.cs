using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ProductGetListSpec : Specification<Product>
    {
        public ProductGetListSpec()
        {
            Query.Where(product => product.ProductIsActive == true)
                .AsNoTracking();
        }
    }
}