using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorDocumentWithDocumentKeySpec : Specification<AdvisorDocument>
    {
        public GetAdvisorDocumentWithDocumentKeySpec(Guid documentId)
        {
            Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            Query.Where(ad => ad.DocumentId == documentId).AsNoTracking();
        }
    }

    public class GetAdvisorIdentityDocumentWithDocumentKeySpec : Specification<AdvisorIdentityDocument>
    {
        public GetAdvisorIdentityDocumentWithDocumentKeySpec(Guid documentId)
        {
            Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            Query.Where(aid => aid.DocumentId == documentId).AsNoTracking();
        }
    }

    public class GetBusinessUnitDocumentWithDocumentKeySpec : Specification<BusinessUnitDocument>
    {
        public GetBusinessUnitDocumentWithDocumentKeySpec(Guid documentId)
        {
            Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            Query.Where(bud => bud.DocumentId == documentId).AsNoTracking();
        }
    }

    public class GetCustomerDocumentWithDocumentKeySpec : Specification<CustomerDocument>
    {
        public GetCustomerDocumentWithDocumentKeySpec(Guid documentId)
        {
            Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            Query.Where(cd => cd.DocumentId == documentId).AsNoTracking();
        }
    }

    public class GetMessageDocumentWithDocumentKeySpec : Specification<MessageDocument>
    {
        public GetMessageDocumentWithDocumentKeySpec(Guid documentId)
        {
            Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            Query.Where(md => md.DocumentId == documentId).AsNoTracking();
        }
    }

    public class GetTemplateDocumentWithDocumentKeySpec : Specification<TemplateDocument>
    {
        public GetTemplateDocumentWithDocumentKeySpec(Guid documentId)
        {
            Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            Query.Where(td => td.DocumentId == documentId).AsNoTracking();
        }
    }

    public class GetVoiceNoteDocumentWithDocumentKeySpec : Specification<VoiceNoteDocument>
    {
        public GetVoiceNoteDocumentWithDocumentKeySpec(Guid documentId)
        {
            Guard.Against.NullOrEmpty(documentId, nameof(documentId));
            Query.Where(vnd => vnd.DocumentId == documentId).AsNoTracking();
        }
    }
}