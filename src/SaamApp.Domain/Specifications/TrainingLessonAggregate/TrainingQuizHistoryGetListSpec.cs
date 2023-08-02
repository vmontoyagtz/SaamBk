using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TrainingQuizHistoryGetListSpec : Specification<TrainingQuizHistory>
    {
        public TrainingQuizHistoryGetListSpec()
        {
            Query.OrderBy(trainingQuizHistory => trainingQuizHistory.TrainingQuizHistoryId)
                .AsNoTracking();
        }
    }
}