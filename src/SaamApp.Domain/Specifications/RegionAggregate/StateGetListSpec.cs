using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class StateGetListSpec : Specification<State>
    {
        public StateGetListSpec()
        {
            Query.OrderBy(state => state.StateId)
                .AsNoTracking();
        }
    }
}