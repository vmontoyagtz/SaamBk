using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TrainingLessonGetListSpec : Specification<TrainingLesson>
    {
        public TrainingLessonGetListSpec()
        {
            Query.OrderBy(trainingLesson => trainingLesson.TrainingLessonId)
                .AsNoTracking();
        }
    }
}