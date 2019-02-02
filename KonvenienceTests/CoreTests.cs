using System;
using FluentAssertions;
using NUnit.Framework;

namespace Konvenience.Tests
{
    class CoreTests
    {
        [Test]
        public void Test_Using_Also_In_An_Object()
        {
            var dummy = new DummyClass();

            var result = dummy.Also(d => d.Configure());

            result.Should().BeSameAs(dummy);
        }

        [Test]
        public void Test_Using_Also_With_A_Null_Object()
        {
            string value = null;
            var executed = false;

            var result = value.Also(v => executed = true);

            result.Should().BeNull();
            executed.Should().BeTrue();
        }

        [Test]
        public void Test_Using_Also_With_A_Null_Argument()
        {
            var dummy = new DummyClass();

            dummy.Invoking(d => d.Also(null))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}
