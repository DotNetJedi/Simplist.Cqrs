using System;
using System.Collections;

namespace Simplist.Cqrs.Core
{
    public interface IRepository<T> where T : IEventSourced
    {
        void Save(T eventSourced);
        T Get(Guid id);
    }
}