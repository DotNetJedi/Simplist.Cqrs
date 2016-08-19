using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Simplist.Cqrs.Core.Domain;

namespace Simplist.Core.Domain
{
    [TestFixture]
    public class RepositoryTests
    {
        private Guid _id;
        private Mock<IEventStore> _storeMock;

        [SetUp]
        public void Setup()
        {
            _id = GuidMaker.Get(1);
            _storeMock = new Mock<IEventStore>();
        }

        [Test]
        public void Repository_should_assign_id()
        {
            var repository = new Repository<TestEntity>(_storeMock.Object);
            var eventSourced = repository.Get(_id);
            eventSourced.Id.Should().Be(_id);
        }

        [Test]
        public void Entity_should_apply_events()
        {
            _storeMock.Setup(m => m.GetEvents(_id))
                .Returns(new[]
                {
                    new CreateEntityEvent(_id), 
                });

            var repository = new Repository<TestEntity>(_storeMock.Object);
            var testEntity = repository.Get(_id);
            _storeMock.Verify(m => m.GetEvents(_id), Times.Once);
            testEntity.IsApplied().Should().BeTrue();
        }
    }

    public class TestEntity : EventSourcedBase
    {
        private bool _isApplied;

        public TestEntity()
        {
        }

        public virtual void Apply(CreateEntityEvent domainEvent)
        {
            if (domainEvent != null) _isApplied = true;
        }

        public bool IsApplied() => _isApplied;
    }

    public class CreateEntityEvent : DomainEvent
    {
        public CreateEntityEvent(Guid id) : base(id)
        {
        }
    }
}