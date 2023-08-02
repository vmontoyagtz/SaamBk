using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiFeedbackGetListSpec : Specification<AiFeedback>
    {
        public AiFeedbackGetListSpec()
        {
            Query.Where(aiFeedback => aiFeedback.UserFeedback == true)
                .AsNoTracking();
        }
    }
}