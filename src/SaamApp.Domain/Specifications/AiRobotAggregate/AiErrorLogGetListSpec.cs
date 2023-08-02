using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiErrorLogGetListSpec : Specification<AiErrorLog>
    {
        public AiErrorLogGetListSpec()
        {
            Query.OrderBy(aiErrorLog => aiErrorLog.AiErrorLogId)
                .AsNoTracking();
        }
    }
}