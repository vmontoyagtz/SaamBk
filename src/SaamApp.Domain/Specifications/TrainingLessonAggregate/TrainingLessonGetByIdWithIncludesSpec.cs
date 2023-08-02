using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TrainingLessonByIdWithIncludesSpec : Specification<TrainingLesson>, ISingleResultSpecification
    {
        public TrainingLessonByIdWithIncludesSpec(Guid trainingLessonId)
        {
            Guard.Against.NullOrEmpty(trainingLessonId, nameof(trainingLessonId));
            Query.Where(trainingLesson => trainingLesson.TrainingLessonId == trainingLessonId)
                .Include(a => a.TrainingProgresses)
                .ThenInclude(b => b.Advisor)
                .AsNoTracking();
        }
    }
}