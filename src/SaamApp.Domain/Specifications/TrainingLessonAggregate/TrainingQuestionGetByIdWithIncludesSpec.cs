using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TrainingQuestionByIdWithIncludesSpec : Specification<TrainingQuestion>, ISingleResultSpecification
    {
        public TrainingQuestionByIdWithIncludesSpec(Guid trainingQuestionId)
        {
            Guard.Against.NullOrEmpty(trainingQuestionId, nameof(trainingQuestionId));
            Query.Where(trainingQuestion => trainingQuestion.TrainingQuestionId == trainingQuestionId)
                .Include(a => a.TrainingQuestionOptions)
                .AsNoTracking();
        }
    }
}