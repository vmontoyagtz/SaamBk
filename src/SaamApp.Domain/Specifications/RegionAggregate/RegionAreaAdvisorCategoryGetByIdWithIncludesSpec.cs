using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class RegionAreaAdvisorCategoryByIdWithIncludesSpec : Specification<RegionAreaAdvisorCategory>,
        ISingleResultSpecification
    {
        public RegionAreaAdvisorCategoryByIdWithIncludesSpec(Guid regionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Query.Where(regionAreaAdvisorCategory =>
                    regionAreaAdvisorCategory.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId)
                .Include(a => a.Advisor)
                .Include(b => b.Area)
                .Include(c => c.Category)
                .Include(d => d.Region)
                .Include(e => e.AdvisorApplicants)
                .Include(e => e.AiAreaExpertises)
                .Include(e => e.AiRobotCategories)
                .ThenInclude(f => f.AiRobot).Include(f => f.AiRobotCategories).ThenInclude(f => f.Comission)
                .Include(f => f.BusinessUnitCategories)
                .ThenInclude(g => g.BusinessUnit)
                .Include(g => g.Comissions)
                .Include(g => g.Conversations)
                .Include(h => h.Messages)
                .Include(i => i.ProductCategories)
                .ThenInclude(j => j.Comission).Include(j => j.ProductCategories).ThenInclude(j => j.Product)
                .Include(j => j.TemplateCategories)
                .ThenInclude(k => k.Comission).Include(k => k.TemplateCategories).ThenInclude(k => k.Template)
                .Include(k => k.UnansweredConversations)
                .AsNoTracking();
        }
    }
}