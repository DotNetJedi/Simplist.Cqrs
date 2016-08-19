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
        [Test]
        public void Repository_should_assign_id()
        {
            var id = GuidMaker.Get(1);
            var storeMock = new Mock<IEventStore>();
            var repository = new Repository<Entity>(storeMock.Object);

            var eventSourced = repository.Get(id);

            eventSourced.Id.Should().Be(id);
        }
    }

    public class Entity : EventSourcedBase
    {
        public Entity()
        {
        }

        public override Guid Id { get; set; }
    }
}