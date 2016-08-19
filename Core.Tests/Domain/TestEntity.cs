using Simplist.Cqrs.Core.Domain;

namespace Simplist.Core.Domain
{
    public sealed class TestEntity : EventSourcedBase
    {
        private bool _isApplied;

        public void Apply(CreateEntityEvent domainEvent)
        {
            _isApplied = Id == domainEvent.Id;
        }

        public bool IsApplied() => _isApplied;
    }
}