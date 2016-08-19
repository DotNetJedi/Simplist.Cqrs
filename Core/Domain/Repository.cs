using System;

namespace Simplist.Cqrs.Core.Domain
{
    public class Repository<T> : IRepository<T> where T : EventSourcedBase, new()
    {
        public Repository(IEventStore eventStore)
        {
            
        }

        public void Save(T eventSourced)
        {
            throw new NotImplementedException();
        }

        public T Get(Guid id)
        {
            var entity = new T {Id = id};
            return entity;
        }
    }
}