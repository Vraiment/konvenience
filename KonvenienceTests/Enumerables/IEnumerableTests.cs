using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

using static NUnit.Framework.Assert;

namespace Konvenience.Enumerables
{
    class IEnumerableTests
    {
        private static char[] SampleArray()
            => new char[] { 'a', 'b', 'c', 'd' };

        #region ForEach
        [Test]
        public void Test_ForEach_In_An_IEnumerable()
        {
            char[] expected = SampleArray();
            IEnumerable<char> enumerable = Enumerable.For(expected);
            int index = 0;

            enumerable.ForEach(e => e.Should().Be(expected[index++]));
        }

        [Test]
        public void Test_ForEach_With_Index_In_An_IEnumerable()
        {
            char[] array = SampleArray();
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
            .Invoking(e => e.ForEach(_ => Fail("This should never be executed")))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("enumerable"));

        [Test]
        public void Test_ForEach_With_Index_In_A_Null_IEnumerable()
            => Null
                .As<IEnumerable<char>>()
                .Invoking(e => e.ForEach((_, i) => Fail("This should never be executed")))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("enumerable"));

        [Test]
        public void Test_ForEach_In_An_IEnumerable_With_A_Null_Action()
            => SampleArray()
                .Invoking(a => a.ForEach(Null.As<Action<char>>()))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("action"));

        [Test]
        public void Test_ForEach_With_Index_In_An_IEnumerable_With_A_Null_Action()
            => SampleArray()
                .Invoking(a => a.ForEach(Null.As<Action<char, int>>()))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("action"));
        #endregion

        #region Get
        [Test]
        public void Test_Get_A_Valid_Index_In_An_IEnumerable()
        {
            char[] array = SampleArray();
            IEnumerable<char> enumerable = Enumerable.For(array);
            int index = 0;

            enumerable.Get(index)
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_Get_An_Invalid_Index_In_An_IEnumerable()
            => Enumerable.For<char>()
                .Invoking(a => a.Get(0))
                .Should()
                .Throw<ArgumentOutOfRangeException>()
                .Where(e => e.Message.Contains("index"));

        [Test]
        public void Test_Get_In_A_Null_IEnumerable() => Null
            .As<IEnumerable<char>>()
            .Invoking(n => n.Get(0))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("enumerable"));
        #endregion

        #region GetOrElse
        [Test]
        public void Test_GetOrElse_A_Valid_Index_In_An_IEnumerable()
        {
            char[] array = SampleArray();
            IEnumerable<char> enumerable = Enumerable.For(array);
            int index = 0;

            enumerable.GetOrElse(index, 'z')
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_GetOrElse_An_Invalid_Index_In_An_IEnumerable()
        {
            char[] array = SampleArray();
            IEnumerable<char> enumerable = Enumerable.For(array);

            enumerable.GetOrElse(array.Length, 'z')
                .Should()
                .Be('z');
        }

        [Test]
        public void Test_GetOrElse_In_A_Null_IEnumerable() => Null
            .As<IEnumerable<char>>()
            .Invoking(e => e.GetOrElse(0, 'z'))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("enumerable"));

        [Test]
        public void Test_GetOrElse_With_A_Function_A_Valid_Index_In_An_IEnumerable()
        {
            char[] array = SampleArray();
            IEnumerable<char> enumerable = Enumerable.For(array);
            int index = 0;

            enumerable.GetOrElse(index, () => 'z')
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_An_Invalid_Index_In_An_IEnumerable()
        {
            char[] array = SampleArray();
            IEnumerable<char> enumerable = Enumerable.For(array);

            enumerable.GetOrElse(array.Length, () => 'z')
                .Should()
                .Be('z');
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_In_A_Null_IEnumerable() => Null
            .As<IEnumerable<char>>()
            .Invoking(e => e.GetOrElse(0, () => 'z'))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("enumerable"));

        [Test]
        public void Test_GetOrElse_With_A_Null_Function_In_An_IEnumerable()
            => Enumerable.For<char>()
                .Invoking(e => e.GetOrElse(0, null))
                .Should()
                .Throw<ArgumentException>()
                .Where(e => e.Message.Contains("function"));
        #endregion

        #region IsEmpty/IsNotEmpty
        [Test]
        public void Test_Emptiness_Of_A_Non_Empty_IEnumerable()
        {
            IEnumerable<char> enumerable = Enumerable.For(SampleArray());

            enumerable.IsEmpty().Should().BeFalse();
            enumerable.IsNotEmpty().Should().BeTrue();
        }

        [Test]
        public void Test_Emptiness_Of_An_Empty_IEnumerable()
        {
            IEnumerable<char> enumerable = Enumerable.For<char>();

            enumerable.IsEmpty().Should().BeTrue();
            enumerable.IsNotEmpty().Should().BeFalse();
        }

        [Test]
        public void Test_Emptiness_Of_A_Null_IEnumerable()
        {
            IEnumerable<char> enumerable = null;

            enumerable
                .Invoking(a => a.IsEmpty())
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("enumerable"));

            enumerable
                .Invoking(a => a.IsNotEmpty())
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("enumerable"));
        }
        #endregion
    }
}
