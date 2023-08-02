using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TrainingQuestionGetListSpec : Specification<TrainingQuestion>
    {
        public TrainingQuestionGetListSpec()
        {
            Query.OrderBy(trainingQuestion => trainingQuestion.TrainingQuestionId)
                .AsNoTracking();
        }
    }
}