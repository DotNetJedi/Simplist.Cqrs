using System;
using System.Collections.Generic;

namespace Simplist.Cqrs.Core.Domain
{
    public abstract class EventSourcedBase : IEventSourced
    {
        private readonly List<DomainEvent> _changes = new List<DomainEvent>();

        public abstract Guid Id { get; set; }

        //public IEnumerable<DomainEvent> GetPendingEvents()
        //{
        //    return _changes;
        //}
    }
}