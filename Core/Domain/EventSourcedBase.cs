using System;
using System.Collections.Generic;

namespace Simplist.Cqrs.Core.Domain
{
    public abstract class EventSourcedBase : IEventSourced
    {
        private readonly List<DomainEvent> _changes = new List<DomainEvent>();

        public virtual Guid Id { get; internal set; }

        //public IEnumerable<DomainEvent> GetPendingEvents()
        //{
        //    return _changes;
        //}
    }
}