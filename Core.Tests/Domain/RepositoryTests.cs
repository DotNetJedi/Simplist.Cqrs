using System;
using System.Dynamic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Simplist.Cqrs.Core;
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
            var repository = new Repository<Entity>(_storeMock.Object);
            var eventSourced = repository.Get(_id);
            eventSourced.Id.Should().Be(_id);
        }

        [Test]
        public void Repository_should_reload_from_events()
        {
            _storeMock.Setup(m => m.GetEvents(_id))
                .Returns(new[]
                {
                    new Mock<DomainEvent>().Object, 
                });

            var repository = new Repository<Entity>(_storeMock.Object);
            repository.Get(_id);
            _storeMock.Verify(m => m.GetEvents(_id), Times.Once);
        }
    }

    public class Entity : EventSourcedBase
    {
        public Entity()
        {
        }
    }
}