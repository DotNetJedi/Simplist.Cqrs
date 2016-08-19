using System;

namespace Simplist.Cqrs.Core.Domain
{
    public class Repository<T> : IRepository<T> where T : EventSourcedBase, new()
    {
        private readonly IEventStore _eventStore;

        public Repository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        //public void Save(T eventSourced)
        //{
        //    throw new NotImplementedException();
        //}

        public T Get(Guid id)
        {
            var entity = new T { Id = id };
            _eventStore.GetEvents(id);
            return entity;
        }
    }
}