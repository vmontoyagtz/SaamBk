using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class MessageDocumentGetListSpec : Specification<MessageDocument>
    {
        public MessageDocumentGetListSpec()
        {
            Query.OrderBy(messageDocument => messageDocument.RowId)
                .AsNoTracking();
        }
    }
}