using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class MessageTypeGetListSpec : Specification<MessageType>
    {
        public MessageTypeGetListSpec()
        {
            Query.OrderBy(messageType => messageType.MessageTypeId)
                .AsNoTracking();
        }
    }
}