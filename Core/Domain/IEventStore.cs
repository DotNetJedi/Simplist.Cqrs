using System;
using System.Collections.Generic;

namespace Simplist.Cqrs.Core.Domain
{
    public interface IEventStore
    {
        void SaveEvents(Guid id, IEnumerable<DomainEvent> events);
        IEnumerable<DomainEvent> GetEvents(Guid id);
    }
}