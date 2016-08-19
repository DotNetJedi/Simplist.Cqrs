using System;

namespace Simplist.Cqrs.Core.Domain
{
    public abstract class DomainEvent : IDomainMessage
    {
        public Guid Id { get; set; }

        protected DomainEvent(Guid id)
        {
            Id = id;
        }
    }
}