using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaamAppLib.SharedKernel
{
    // This can be modified to EntityBase<TId> to support multiple key types (e.g. Guid)
    public abstract class EntityBase
    {
        private readonly List<BaseDomainEvent> _domainEvents = new();
        public int Id { get; set; }
        [NotMapped] public IEnumerable<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void RegisterDomainEvent(BaseDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        internal void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}