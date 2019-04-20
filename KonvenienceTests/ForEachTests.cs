using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using static NUnit.Framework.Assert;

namespace Konvenience
{
    class ForEachTests
    {
        private static char[] NonEmptyArray()
            => new char[] { 'a', 'b', 'c', 'd' };

        #region ForEach with array tests
        [Test]
        public void Test_ForEach_In_An_Array()
        {
            char[] array = NonEmptyArray();
            int index = 0;

            array.ForEach(e => e.Should().Be(array[index++]));
        }

        [Test]
        public void Test_ForEach_With_Index_In_An_Array()
        {
            char[] array = NonEmptyArray();
            int index = 0;

            array.ForEach((e, i) =>
            {
                i.Should().Be(index);
                e.Should().Be(array[index++]);
            });
        }

        [Test]
        public void Test_ForEach_In_A_Null_Array() => Null
            .As<char[]>()
            .ForEach(e => Fail("This should never be executed"));

        [Test]
        public void Test_ForEach_With_Index_In_A_Null_Array()
            => Null
                .As<char[]>()
                .ForEach((e, i) => Fail("This should never be executed"));

        [Test]
        public void Test_ForEach_In_An_Array_With_A_Null_Action()
            => NonEmptyArray()
                .Invoking(a => a.ForEach(Null.As<Action<char>>()))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("action"));

        [Test]
        public void Test_ForEach_With_Index_In_An_Array_With_A_Null_Action()
            => NonEmptyArray()
                .Invoking(a => a.ForEach(Null.As<Action<char, int>>()))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("action"));
        #endregion

        #region ForEach with IEnumerable<T> tests
        [Test]
        public void Test_ForEach_In_An_IEnumerable()
        {
            char[] expected = NonEmptyArray();
            IEnumerable<char> enumerable = Enumerable.For(expected);
            int index = 0;

            enumerable.ForEach(e => e.Should().Be(expected[index++]));
        }

        [Test]
        public void Test_ForEach_With_Index_In_An_IEnumerable()
        {
            char[] array = NonEmptyArray();
            IEnumerable<char> enumerable = Enumerable.For(array);
            int index = 0;

            enumerable.ForEach((e, i) =>
            {
                i.Should().Be(index);
                e.Should().Be(array[index++]);
            });
        }

        [Test]
        public void Test_ForEach_In_A_Null_IEnumerable() => Null
            .As<IEnumerable<char>>()
            .ForEach(e => Fail("This should never be executed"));

        [Test]
        public void Test_ForEach_With_Index_In_A_Null_IEnumerable()
            => Null
                .As<IEnumerable<char>>()
                .ForEach((e, i) => Fail("This should never be executed"));

        [Test]
        public void Test_ForEach_In_An_IEnumerable_With_A_Null_Action()
            => NonEmptyArray()
                .Invoking(a => a.ForEach(Null.As<Action<char>>()))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("action"));

        [Test]
        public void Test_ForEach_With_Index_In_An_IEnumerable_With_A_Null_Action()
            => NonEmptyArray()
                .Invoking(a => a.ForEach(Null.As<Action<char, int>>()))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("action"));
        #endregion
    }
}
