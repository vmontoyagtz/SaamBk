using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorBankTransferInfoGetListSpec : Specification<AdvisorBankTransferInfo>
    {
        public AdvisorBankTransferInfoGetListSpec()
        {
            Query.Where(advisorBankTransferInfo => advisorBankTransferInfo.IsDeleted == false)
                .AsNoTracking();
        }
    }
}