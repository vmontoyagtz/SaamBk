using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BankGetListSpec : Specification<Bank>
    {
        public BankGetListSpec()
        {
            Query.Where(bank => bank.IsDeleted == false)
                .AsNoTracking();
        }
    }
}