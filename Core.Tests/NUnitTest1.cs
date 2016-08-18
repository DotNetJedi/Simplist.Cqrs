using System;
using FluentAssertions;
using Simplist.Cqrs.Core;

using NUnit.Framework;

namespace Core.Tests
{
    [TestFixture]
    public class NUnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var burner = new Burner();

            burner.Should().NotBeNull();

            var result = burner.Smoke("test");

            result.Should().Be("test smoked");
        }
    }
}