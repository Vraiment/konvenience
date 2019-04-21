using FluentAssertions;
using NUnit.Framework;
using System;

using static NUnit.Framework.Assert;

namespace Konvenience.Enumerables
{
    class ArrayTests
    {
        private static char[] SampleArray()
            => new char[] { 'a', 'b', 'c', 'd' };

        #region ForEach
        [Test]
        public void Test_ForEach_In_An_Array()
        {
            char[] array = SampleArray();
            int index = 0;

            array.ForEach(e => e.Should().Be(array[index++]));
        }

        [Test]
        public void Test_ForEach_With_Index_In_An_Array()
        {
            char[] array = SampleArray();
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
            .Invoking(a => a.ForEach(_ => Fail("This should never be executed")))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("array"));

        [Test]
        public void Test_ForEach_With_Index_In_A_Null_Array()
            => Null
                .As<char[]>()
                .Invoking(a => a.ForEach((_, i) => Fail("This should never be executed")))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("array"));

        [Test]
        public void Test_ForEach_In_An_Array_With_A_Null_Action()
            => SampleArray()
                .Invoking(a => a.ForEach(Null.As<Action<char>>()))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("action"));

        [Test]
        public void Test_ForEach_With_Index_In_An_Array_With_A_Null_Action()
            => SampleArray()
                .Invoking(a => a.ForEach(Null.As<Action<char, int>>()))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("action"));
        #endregion

        #region Get
        [Test]
        public void Test_Get_A_Valid_Index_In_An_Array()
        {
            char[] array = SampleArray();
            int index = 0;

            array.Get(index)
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_Get_An_Invalid_Index_In_An_Array()
        {
            char[] array = SampleArray();

            array
                .Invoking(a => a.Get(array.Length))
                .Should()
                .Throw<ArgumentOutOfRangeException>()
                .Where(e => e.Message.Contains("index"));
        }

        [Test]
        public void Test_Get_In_A_Null_Array() => Null
            .As<char[]>()
            .Invoking(n => n.Get(0))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("array"));
        #endregion

        #region GetOrElse
        [Test]
        public void Test_GetOrElse_A_Valid_Index_In_An_Array()
        {
            char[] array = SampleArray();
            int index = 0;

            array.GetOrElse(index, 'z')
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_GetOrElse_An_Invalid_Index_In_An_Array()
        {
            char[] array = SampleArray();

            array.GetOrElse(array.Length, 'z')
                .Should()
                .Be('z');
        }

        [Test]
        public void Test_GetOrElse_In_A_Null_Array() => Null
            .As<char[]>()
            .Invoking(a => a.GetOrElse(0, 'z'))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("array"));

        [Test]
        public void Test_GetOrElse_With_A_Function_A_Valid_Index_In_An_Array()
        {
            char[] array = SampleArray();
            int index = 0;

            array.GetOrElse(index, () => 'z')
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_An_Invalid_Index_In_An_Array()
        {
            char[] array = SampleArray();

            array.GetOrElse(array.Length, () => 'z')
                .Should()
                .Be('z');
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_In_A_Null_Array() => Null
            .As<char[]>()
            .Invoking(a => a.GetOrElse(0, () => 'z'))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("array"));

        [Test]
        public void Test_GetOrElse_With_A_Null_Function_In_An_Array()
        {
            char[] array = SampleArray();

            array
                .Invoking(a => a.GetOrElse(0, null))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("function"));
        }
        #endregion
    }
}
