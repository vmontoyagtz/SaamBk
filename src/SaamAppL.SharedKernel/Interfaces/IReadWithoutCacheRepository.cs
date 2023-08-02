using Ardalis.Specification;

namespace SaamAppLib.SharedKernel.Interfaces
{
    public interface IReadWithoutCacheRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}