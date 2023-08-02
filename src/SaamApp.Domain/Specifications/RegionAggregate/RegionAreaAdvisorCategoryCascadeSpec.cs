using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorApplicantWithRegionAreaAdvisorCategoryKeySpec : Specification<AdvisorApplicant>
    {
        public GetAdvisorApplicantWithRegionAreaAdvisorCategoryKeySpec(Guid regionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Query.Where(aa => aa.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId).AsNoTracking();
        }
    }

    public class GetAiAreaExpertiseWithRegionAreaAdvisorCategoryKeySpec : Specification<AiAreaExpertise>
    {
        public GetAiAreaExpertiseWithRegionAreaAdvisorCategoryKeySpec(Guid regionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Query.Where(aae => aae.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId).AsNoTracking();
        }
    }

    public class GetAiRobotCategoryWithRegionAreaAdvisorCategoryKeySpec : Specification<AiRobotCategory>
    {
        public GetAiRobotCategoryWithRegionAreaAdvisorCategoryKeySpec(Guid regionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Query.Where(arc => arc.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId).AsNoTracking();
        }
    }

    public class GetBusinessUnitCategoryWithRegionAreaAdvisorCategoryKeySpec : Specification<BusinessUnitCategory>
    {
        public GetBusinessUnitCategoryWithRegionAreaAdvisorCategoryKeySpec(Guid regionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Query.Where(buc => buc.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId).AsNoTracking();
        }
    }

    public class GetComissionWithRegionAreaAdvisorCategoryKeySpec : Specification<Comission>
    {
        public GetComissionWithRegionAreaAdvisorCategoryKeySpec(Guid regionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Query.Where(c => c.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId).AsNoTracking();
        }
    }

    public class GetConversationWithRegionAreaAdvisorCategoryKeySpec : Specification<Conversation>
    {
        public GetConversationWithRegionAreaAdvisorCategoryKeySpec(Guid regionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Query.Where(c => c.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId).AsNoTracking();
        }
    }

    public class GetMessageWithRegionAreaAdvisorCategoryKeySpec : Specification<Message>
    {
        public GetMessageWithRegionAreaAdvisorCategoryKeySpec(Guid regionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Query.Where(m => m.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId).AsNoTracking();
        }
    }

    public class GetProductCategoryWithRegionAreaAdvisorCategoryKeySpec : Specification<ProductCategory>
    {
        public GetProductCategoryWithRegionAreaAdvisorCategoryKeySpec(Guid regionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Query.Where(pc => pc.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId).AsNoTracking();
        }
    }

    public class GetTemplateCategoryWithRegionAreaAdvisorCategoryKeySpec : Specification<TemplateCategory>
    {
        public GetTemplateCategoryWithRegionAreaAdvisorCategoryKeySpec(Guid regionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Query.Where(tc => tc.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId).AsNoTracking();
        }
    }

    public class GetUnansweredConversationWithRegionAreaAdvisorCategoryKeySpec : Specification<UnansweredConversation>
    {
        public GetUnansweredConversationWithRegionAreaAdvisorCategoryKeySpec(Guid regionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Query.Where(uc => uc.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId).AsNoTracking();
        }
    }
}