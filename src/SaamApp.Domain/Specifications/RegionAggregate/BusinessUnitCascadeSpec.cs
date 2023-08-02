using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorWithBusinessUnitKeySpec : Specification<Advisor>
    {
        public GetAdvisorWithBusinessUnitKeySpec(Guid businessUnitId)
        {
            Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            Query.Where(a => a.BusinessUnitId == businessUnitId).AsNoTracking();
        }
    }

    public class GetBusinessUnitAddressWithBusinessUnitKeySpec : Specification<BusinessUnitAddress>
    {
        public GetBusinessUnitAddressWithBusinessUnitKeySpec(Guid businessUnitId)
        {
            Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            Query.Where(bua => bua.BusinessUnitId == businessUnitId).AsNoTracking();
        }
    }

    public class GetBusinessUnitCategoryWithBusinessUnitKeySpec : Specification<BusinessUnitCategory>
    {
        public GetBusinessUnitCategoryWithBusinessUnitKeySpec(Guid businessUnitId)
        {
            Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            Query.Where(buc => buc.BusinessUnitId == businessUnitId).AsNoTracking();
        }
    }

    public class GetBusinessUnitDocumentWithBusinessUnitKeySpec : Specification<BusinessUnitDocument>
    {
        public GetBusinessUnitDocumentWithBusinessUnitKeySpec(Guid businessUnitId)
        {
            Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            Query.Where(bud => bud.BusinessUnitId == businessUnitId).AsNoTracking();
        }
    }

    public class GetBusinessUnitEmailAddressWithBusinessUnitKeySpec : Specification<BusinessUnitEmailAddress>
    {
        public GetBusinessUnitEmailAddressWithBusinessUnitKeySpec(Guid businessUnitId)
        {
            Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            Query.Where(buea => buea.BusinessUnitId == businessUnitId).AsNoTracking();
        }
    }

    public class GetBusinessUnitPhoneNumberWithBusinessUnitKeySpec : Specification<BusinessUnitPhoneNumber>
    {
        public GetBusinessUnitPhoneNumberWithBusinessUnitKeySpec(Guid businessUnitId)
        {
            Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            Query.Where(bupn => bupn.BusinessUnitId == businessUnitId).AsNoTracking();
        }
    }

    public class GetTaxInformationWithBusinessUnitKeySpec : Specification<TaxInformation>
    {
        public GetTaxInformationWithBusinessUnitKeySpec(Guid businessUnitId)
        {
            Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            Query.Where(ti => ti.BusinessUnitId == businessUnitId).AsNoTracking();
        }
    }
}