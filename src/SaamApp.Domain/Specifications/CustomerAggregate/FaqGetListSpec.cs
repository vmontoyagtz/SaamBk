using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class FaqGetListSpec : Specification<Faq>
    {
        public FaqGetListSpec()
        {
            Query.OrderBy(faq => faq.FaqId)
                .AsNoTracking();
        }
    }
}