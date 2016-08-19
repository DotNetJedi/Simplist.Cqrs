using System;

namespace Simplist.Cqrs.Core.Domain
{
    public abstract class DomainEvent : IDomainMessage
    {
        public abstract Guid Id { get; set; }
    }
}