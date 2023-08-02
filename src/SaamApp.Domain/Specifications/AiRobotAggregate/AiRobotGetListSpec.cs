using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiRobotGetListSpec : Specification<AiRobot>
    {
        public AiRobotGetListSpec()
        {
            Query.Where(aiRobot => aiRobot.AiRobotIsActive == true)
                .AsNoTracking();
        }
    }
}