using Ardalis.Specification;

namespace SaamAppLib.SharedKernel.Interfaces
{
    //   we've also implemented IRepository of T similarly it also inherits from a type
    // that comes from our specification and also has the same IAggregate restriction
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}