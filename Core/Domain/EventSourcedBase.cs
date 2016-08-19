using System;
using System.Collections.Generic;

namespace Simplist.Cqrs.Core.Domain
{
    public abstract class EventSourcedBase : IEventSourced
    {
        // private readonly List<DomainEvent> _changes = new List<DomainEvent>();

        public virtual Guid Id { get; internal set; }
        public void LoadFromEvents(IEnumerable<DomainEvent> history)
        {
            foreach (var domainEvent in history)
            {
                ApplyEvent(domainEvent);
            }
        }

        private void ApplyEvent(DomainEvent domainEvent)
        {
            this.AsDynamic().Apply(domainEvent);
        }

        //public IEnumerable<DomainEvent> GetPendingEvents()
        //{
        //    return _changes;
        //}
    }
}