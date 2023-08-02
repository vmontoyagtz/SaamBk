using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TrainingProgressGetListSpec : Specification<TrainingProgress>
    {
        public TrainingProgressGetListSpec()
        {
            Query.Where(trainingProgress => trainingProgress.IsDeleted == false)
                .AsNoTracking();
        }
    }
}