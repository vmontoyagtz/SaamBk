using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetTrainingQuestionOptionWithTrainingQuestionKeySpec : Specification<TrainingQuestionOption>
    {
        public GetTrainingQuestionOptionWithTrainingQuestionKeySpec(Guid trainingQuestionId)
        {
            Guard.Against.NullOrEmpty(trainingQuestionId, nameof(trainingQuestionId));
            Query.Where(tqo => tqo.TrainingQuestionId == trainingQuestionId).AsNoTracking();
        }
    }
}