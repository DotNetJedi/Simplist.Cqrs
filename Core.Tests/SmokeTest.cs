using System;
using FluentAssertions;
using NUnit.Framework;
using Simplist.Cqrs.Core;

namespace Simplist.Core
{
    [TestFixture]
    public class SmokeTest
    {
        private Burner _burner;

        [SetUp]
        public void Setup()
        {
            _burner = new Burner();
        }

        [Test]
        public void Smoke_test_should_work()
        {
            var result = _burner.Smoke("test");
            result.Should().Be("test smoked");
        }

        [Test]
        public void Smoke_should_validate_for_null()
        {
            _burner.Invoking(_ => _.Smoke(null))
                .ShouldThrow<ArgumentNullException>();
        }
    }
}