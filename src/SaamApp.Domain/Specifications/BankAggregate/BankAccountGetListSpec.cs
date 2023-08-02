using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BankAccountGetListSpec : Specification<BankAccount>
    {
        public BankAccountGetListSpec()
        {
            Query.Where(bankAccount => bankAccount.IsDefault == true)
                .AsNoTracking();
        }
    }
}