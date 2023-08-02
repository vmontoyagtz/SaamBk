using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ComissionByIdWithIncludesSpec : Specification<Comission>, ISingleResultSpecification
    {
        public ComissionByIdWithIncludesSpec(Guid comissionId)
        {
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Query.Where(comission => comission.ComissionId == comissionId)
                .Include(a => a.RegionAreaAdvisorCategory)
                .Include(b => b.AiRobotCategories)
                .ThenInclude(c => c.AiRobot).Include(c => c.AiRobotCategories)
                .ThenInclude(c => c.RegionAreaAdvisorCategory)
                .Include(c => c.ProductCategories)
                .ThenInclude(d => d.Product).Include(d => d.ProductCategories)
                .ThenInclude(d => d.RegionAreaAdvisorCategory)
                .Include(d => d.TemplateCategories)
                .ThenInclude(e => e.RegionAreaAdvisorCategory).Include(e => e.TemplateCategories)
                .ThenInclude(e => e.Template)
                .AsNoTracking();
        }
    }
}