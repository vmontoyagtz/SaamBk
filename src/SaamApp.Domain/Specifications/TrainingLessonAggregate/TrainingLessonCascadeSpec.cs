using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetTrainingProgressWithTrainingLessonKeySpec : Specification<TrainingProgress>
    {
        public GetTrainingProgressWithTrainingLessonKeySpec(Guid trainingLessonId)
        {
            Guard.Against.NullOrEmpty(trainingLessonId, nameof(trainingLessonId));
            Query.Where(tp => tp.TrainingLessonId == trainingLessonId).AsNoTracking();
        }
    }
}