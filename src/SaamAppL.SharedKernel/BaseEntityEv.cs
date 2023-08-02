using System.Collections.Generic;
using JetBrains.Annotations;

namespace SaamAppLib.SharedKernel
{
    public abstract class BaseEntityEv<TId>
    {
        [CanBeNull] public List<BaseDomainEvent> Events = new();
    }
}