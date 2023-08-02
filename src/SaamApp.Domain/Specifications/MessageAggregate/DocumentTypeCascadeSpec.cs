using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorDocumentWithDocumentTypeKeySpec : Specification<AdvisorDocument>
    {
        public GetAdvisorDocumentWithDocumentTypeKeySpec(Guid documentTypeId)
        {
            Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            Query.Where(ad => ad.DocumentTypeId == documentTypeId).AsNoTracking();
        }
    }

    public class GetAdvisorIdentityDocumentWithDocumentTypeKeySpec : Specification<AdvisorIdentityDocument>
    {
        public GetAdvisorIdentityDocumentWithDocumentTypeKeySpec(Guid documentTypeId)
        {
            Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            Query.Where(aid => aid.DocumentTypeId == documentTypeId).AsNoTracking();
        }
    }

    public class GetBusinessUnitDocumentWithDocumentTypeKeySpec : Specification<BusinessUnitDocument>
    {
        public GetBusinessUnitDocumentWithDocumentTypeKeySpec(Guid documentTypeId)
        {
            Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            Query.Where(bud => bud.DocumentTypeId == documentTypeId).AsNoTracking();
        }
    }

    public class GetCustomerDocumentWithDocumentTypeKeySpec : Specification<CustomerDocument>
    {
        public GetCustomerDocumentWithDocumentTypeKeySpec(Guid documentTypeId)
        {
            Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            Query.Where(cd => cd.DocumentTypeId == documentTypeId).AsNoTracking();
        }
    }

    public class GetMessageDocumentWithDocumentTypeKeySpec : Specification<MessageDocument>
    {
        public GetMessageDocumentWithDocumentTypeKeySpec(Guid documentTypeId)
        {
            Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            Query.Where(md => md.DocumentTypeId == documentTypeId).AsNoTracking();
        }
    }

    public class GetTemplateDocumentWithDocumentTypeKeySpec : Specification<TemplateDocument>
    {
        public GetTemplateDocumentWithDocumentTypeKeySpec(Guid documentTypeId)
        {
            Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            Query.Where(td => td.DocumentTypeId == documentTypeId).AsNoTracking();
        }
    }

    public class GetVoiceNoteDocumentWithDocumentTypeKeySpec : Specification<VoiceNoteDocument>
    {
        public GetVoiceNoteDocumentWithDocumentTypeKeySpec(Guid documentTypeId)
        {
            Guard.Against.NullOrEmpty(documentTypeId, nameof(documentTypeId));
            Query.Where(vnd => vnd.DocumentTypeId == documentTypeId).AsNoTracking();
        }
    }
}