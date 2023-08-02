using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ComissionGetListSpec : Specification<Comission>
    {
        public ComissionGetListSpec()
        {
            Query.Where(comission => comission.IsDeleted == false)
                .AsNoTracking();
        }
    }
}