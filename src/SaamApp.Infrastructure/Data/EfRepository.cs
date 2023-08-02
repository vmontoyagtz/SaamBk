using Ardalis.Specification.EntityFrameworkCore;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Infrastructure.Data
{
    // <summary>
    // The code implementation is relatively straightforward.
    // The majority of the desired behavior is inherited from
    // the Entity Framework (EF) repository in the Specification Nuget package,
    // https://github.com/ardalis/Specification/blob/main/Specification.EntityFrameworkCore/src/Ardalis.Specification.EntityFrameworkCore/RepositoryBaseOfT.cs
    // which is called RepositoryBase of T.
    // By inheriting from it, we can include additional constraints.
    // For instance, in this case, we specified that it works only with IAggregateRoot.
    // The repository base of T's definition is available on GitHub, and you can examine
    // the details there. The list async method is as simple as it gets - it delegates to dbContext.
    // Set of the corresponding T type, then calls ToListAsync and passes in a cancellation token if one was provided.
    // </summary>
    public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EfRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}