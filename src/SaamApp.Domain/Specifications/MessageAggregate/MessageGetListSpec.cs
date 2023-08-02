using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class MessageGetListSpec : Specification<Message>
    {
        public MessageGetListSpec()
        {
            Query.Where(message => message.SentByAdvisor == true)
                .AsNoTracking();
        }
    }
}