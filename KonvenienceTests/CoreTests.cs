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

        [Test]
        public void Test_Using_Let_In_An_Object()
        {
            var dummy = new DummyClass();
            var expected = "asdf";

            var result = dummy.Let(d =>
            {
                d.Should().BeSameAs(dummy);
                return expected;
            });

            result.Should().BeSameAs(expected);
        }

        [Test]
        public void Test_Using_Let_With_A_Null_Object()
        {
            string value = null;
            var expected = "asdf";

            var result = value.Let(v =>
            {
                v.Should().BeNull();
                return expected;
            });

            result.Should().BeSameAs(expected);
        }

        [Test]
        public void Test_Using_Let_With_A_Null_Function()
        {
            var dummy = new DummyClass();
            Func<DummyClass, object> function = null;

            dummy.Invoking(d => d.Let(function))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Test]
        public void Test_TakeReferenceIf_With_A_True_Predicate()
        {
            var value = "asdf";

            var result = value.TakeReferenceIf(v => true);

            result.Should().BeSameAs(value);
        }

        [Test]
        public void Test_TakeReferenceIf_With_A_False_Predicate()
        {
            var value = "asdf";

            var result = value.TakeReferenceIf(v => false);

            result.Should().BeNull();
        }

        [Test]
        public void Test_TakeReferenceIf_With_A_Null_Predicate()
        {
            var value = "asdf";

            value.Invoking(v => v.TakeReferenceIf(null))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Test]
        public void Test_TakeReferenceUnless_With_A_True_Predicate()
        {
            var value = "asdf";

            var result = value.TakeReferenceUnless(v => true);

            result.Should().BeNull();
        }

        [Test]
        public void Test_TakeReferenceUnless_With_A_False_Predicate()
        {
            var value = "asdf";

            var result = value.TakeReferenceUnless(v => false);

            result.Should().BeSameAs(value);
        }

        [Test]
        public void Test_TakeReferenceUnless_With_A_Null_Predicate()
        {
            var value = "asdf";

            value.Invoking(v => v.TakeReferenceUnless(null))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}
