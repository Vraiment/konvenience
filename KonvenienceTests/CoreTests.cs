using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

using static NUnit.Framework.Assert;

namespace Konvenience
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
            => Null
                .As<object>()
                .Invoking(o => o.Also(_ => Fail("This should never be executed")))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("obj"));

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
            => Null
                .As<object>()
                .Invoking(o => o.Let(_ =>
                {
                    Fail("This should never be executed");
                    return Null.As<object>();
                }))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("obj"));

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
        public void Test_TakeReferenceIf_With_A_Null_Object()
            => Null
                .As<object>()
                .Invoking(o => o.TakeReferenceIf(_ => true))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("obj"));

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
        public void Test_TakeReferenceUnless_With_A_Null_Object()
            => Null
                .As<object>()
                .Invoking(o => o.TakeReferenceUnless(_ => true))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("obj"));

        [Test]
        public void Test_TakeReferenceUnless_With_A_Null_Predicate()
        {
            var value = "asdf";

            value.Invoking(v => v.TakeReferenceUnless(null))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Test]
        public void Test_TakeValueIf_With_A_True_Predicate()
        {
            var value = 1;

            var result = value.TakeValueIf(v => true);

            result.Should().Be(value);
        }

        [Test]
        public void Test_TakeValueIf_With_A_False_Predicate()
        {
            var value = 1;

            var result = value.TakeValueIf(v => false);

            result.Should().BeNull();
        }

        [Test]
        public void Test_TakeValueIf_With_A_Null_Predicate()
        {
            var value = 1;

            value.Invoking(v => v.TakeValueIf(null))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Test]
        public void Test_TakeValueUnless_With_A_True_Predicate()
        {
            var value = 1;

            var result = value.TakeValueUnless(v => true);

            result.Should().BeNull();
        }

        [Test]
        public void Test_TakeValueUnless_With_A_False_Predicate()
        {
            var value = 1;

            var result = value.TakeValueUnless(v => false);

            result.Should().Be(value);
        }

        [Test]
        public void Test_TakeValueUnless_With_A_Null_Predicate()
        {
            var value = 1;

            value.Invoking(v => v.TakeValueUnless(null))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Test]
        public void Test_Safe_Casting_An_Object_To_A_Valid_Type()
        {
            string value = "value";

            value
                .As<IEnumerable<char>>()
                .Should()
                .BeSameAs(value);
        }

        [Test]
        public void Test_Safe_Casting_An_Object_To_An_Invalid_Type()
        {
            string value = "value";

            value
                .As<IList<char>>()
                .Should()
                .BeNull();
        }

        [Test]
        public void Test_Safe_Casting_Null() => Core
            .As<IList<char>>(Null.As<string>())
            .Should()
            .BeNull();
    }
}
