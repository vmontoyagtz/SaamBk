using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TrainingQuestionOptionByIdWithIncludesSpec : Specification<TrainingQuestionOption>,
        ISingleResultSpecification
    {
        public TrainingQuestionOptionByIdWithIncludesSpec(Guid trainingQuestionOptionId)
        {
            Guard.Against.NullOrEmpty(trainingQuestionOptionId, nameof(trainingQuestionOptionId));
            Query.Where(trainingQuestionOption =>
                    trainingQuestionOption.TrainingQuestionOptionId == trainingQuestionOptionId)
                .Include(a => a.TrainingQuestion)
                .AsNoTracking();
        }
    }
}