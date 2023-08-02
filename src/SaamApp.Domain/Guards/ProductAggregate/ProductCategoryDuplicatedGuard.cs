using System.Collections.Generic;
using System.Linq;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class ProductCategoryGuardExtensions
    {
        public static void DuplicateProductCategory(this IGuardClause guardClause,
            IEnumerable<ProductCategory> existingProductCategories, ProductCategory newProductCategory,
            string parameterName)
        {
            if (existingProductCategories.Any(a => a.RowId == newProductCategory.RowId))
            {
                throw new DuplicateProductCategoryException("Cannot add duplicate productCategory.", parameterName);
            }
        }
    }
}