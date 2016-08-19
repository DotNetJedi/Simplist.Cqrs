using System;
using System.Collections.Generic;
using Simplist.Cqrs.Core.Domain;

namespace Simplist.Cqrs.Core
{
    public interface IEventSourced
    {
        Guid Id { get; }
        IEnumerable<DomainEvent> GetPendingEvents();
    }
}