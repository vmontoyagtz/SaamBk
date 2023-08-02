using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class UserSessionGetListSpec : Specification<UserSession>
    {
        public UserSessionGetListSpec()
        {
            Query.OrderBy(userSession => userSession.SessionId)
                .AsNoTracking();
        }
    }
}