namespace SaamAppLib.SharedKernel.Interfaces
{
    // <summary>
    // IAggregateRoot is often referred to as a marker interface,

    // An aggregate root is a special type of object in DDD that serves as the root of an aggregate,
    // a cluster of objects that are bound together by a transactional boundary.

    // The aggregate root acts as the single source of truth for the state of the aggregate
    // and is responsible for enforcing invariants and business rules.

    // The IAggregateRoot interface typically does not contain any members or methods,
    // it simply serves as a marker to indicate that a class is an aggregate root.
    // By implementing this interface, a class is signaling that it adheres to the
    // contract and behaviors of an aggregate root, which can be useful for code
    // organization and enforcing design principles.

    // </summary>
    public interface IAggregateRoot
    {
    }
}