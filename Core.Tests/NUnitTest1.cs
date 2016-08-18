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
            var class1 = new Class1();

            class1.Should().NotBeNull();
        }
    }
}