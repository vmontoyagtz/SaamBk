using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TrainingQuestionOptionGetListSpec : Specification<TrainingQuestionOption>
    {
        public TrainingQuestionOptionGetListSpec()
        {
            Query.OrderBy(trainingQuestionOption => trainingQuestionOption.TrainingQuestionOptionId)
                .AsNoTracking();
        }
    }
}