using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Konvenience
{
    class EnumerablesGetTests
    {
        private static char[] NonEmptyArray()
            => new char[] { 'a', 'b', 'c', 'd' };

        #region Get with array tests
        [Test]
        public void Test_Get_A_Valid_Index_In_An_Array()
        {
            char[] array = NonEmptyArray();
            int index = 0;

            array.Get(index)
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_Get_An_Invalid_Index_In_An_Array()
        {
            char[] array = NonEmptyArray();

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

        [Test]
        public void Test_GetOrElse_A_Valid_Index_In_An_Array()
        {
            char[] array = NonEmptyArray();
            int index = 0;

            array.GetOrElse(index, 'z')
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_GetOrElse_An_Invalid_Index_In_An_Array()
        {
            char[] array = NonEmptyArray();

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
            char[] array = NonEmptyArray();
            int index = 0;

            array.GetOrElse(index, () => 'z')
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_An_Invalid_Index_In_An_Array()
        {
            char[] array = NonEmptyArray();

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
            char[] array = NonEmptyArray();

            array
                .Invoking(a => a.GetOrElse(0, null))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("function"));
        }
        #endregion

        #region Get with IEnumerable<T> tests
        [Test]
        public void Test_Get_A_Valid_Index_In_An_IEnumerable()
        {
            char[] array = NonEmptyArray();
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

        [Test]
        public void Test_GetOrElse_A_Valid_Index_In_An_IEnumerable()
        {
            char[] array = NonEmptyArray();
            IEnumerable<char> enumerable = Enumerable.For(array);
            int index = 0;

            enumerable.GetOrElse(index, 'z')
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_GetOrElse_An_Invalid_Index_In_An_IEnumerable()
        {
            char[] array = NonEmptyArray();
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
            char[] array = NonEmptyArray();
            IEnumerable<char> enumerable = Enumerable.For(array);
            int index = 0;

            enumerable.GetOrElse(index, () => 'z')
                .Should()
                .Be(array[index]);
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_An_Invalid_Index_In_An_IEnumerable()
        {
            char[] array = NonEmptyArray();
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

        private static List<char> NonEmptyList()
            => new List<char> { 'a', 'b', 'c', 'd' };

        #region Get with IList<T> tests
        [Test]
        public void Test_Get_A_Valid_Index_In_An_IList()
        {
            IList<char> list = NonEmptyList();
            int index = 0;

            list.Get(index)
                .Should()
                .Be(list[index]);
        }

        [Test]
        public void Test_Get_An_Invalid_Index_In_An_IList()
        {
            IList<char> list = NonEmptyList();

            list
                .Invoking(a => a.Get(list.Count))
                .Should()
                .Throw<ArgumentOutOfRangeException>()
                .Where(e => e.Message.Contains("index"));
        }

        [Test]
        public void Test_Get_In_A_Null_IList() => Null
            .As<IList<char>>()
            .Invoking(n => n.Get(0))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("list"));

        [Test]
        public void Test_GetOrElse_A_Valid_Index_In_An_IList()
        {
            IList<char> list = NonEmptyList();
            int index = 0;

            list.GetOrElse(index, 'z')
                .Should()
                .Be(list[index]);
        }

        [Test]
        public void Test_GetOrElse_An_Invalid_Index_In_An_IList()
        {
            IList<char> list = NonEmptyList();

            list.GetOrElse(list.Count, 'z')
                .Should()
                .Be('z');
        }

        [Test]
        public void Test_GetOrElse_In_A_Null_IList() => Null
            .As<IList<char>>()
            .Invoking(l => l.GetOrElse(0, 'z'))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("list"));

        [Test]
        public void Test_GetOrElse_With_A_Function_A_Valid_Index_In_An_IList()
        {
            IList<char> list = NonEmptyList();
            int index = 0;

            list.GetOrElse(index, () => 'z')
                .Should()
                .Be(list[index]);
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_An_Invalid_Index_In_An_IList()
        {
            IList<char> list = NonEmptyList();

            list.GetOrElse(list.Count, () => 'z')
                .Should()
                .Be('z');
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_In_A_Null_IList() => Null
            .As<IList<char>>()
            .Invoking(l => l.GetOrElse(0, () => 'z'))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("list"));

        [Test]
        public void Test_GetOrElse_With_A_Null_Function_In_A_IList()
        {
            IList<char> list = NonEmptyList();

            list
                .Invoking(l => l.GetOrElse(0, null))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("function"));
        }
        #endregion

        #region Get with IReadOnlyList<T> tests
        [Test]
        public void Test_Get_A_Valid_Index_In_An_IReadOnlyList()
        {
            IReadOnlyList<char> list = NonEmptyList();
            int index = 0;

            list.Get(index)
                .Should()
                .Be(list[index]);
        }

        [Test]
        public void Test_Get_An_Invalid_Index_In_An_IReadOnlyList()
        {
            IReadOnlyList<char> list = NonEmptyList();

            list
                .Invoking(a => a.Get(list.Count))
                .Should()
                .Throw<ArgumentOutOfRangeException>()
                .Where(e => e.Message.Contains("index"));
        }

        [Test]
        public void Test_Get_In_A_Null_IReadOnlyList() => Null
            .As<IReadOnlyList<char>>()
            .Invoking(n => n.Get(0))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("list"));

        [Test]
        public void Test_GetOrElse_A_Valid_Index_In_An_IReadOnlyList()
        {
            IReadOnlyList<char> list = NonEmptyList();
            int index = 0;

            list.GetOrElse(index, 'z')
                .Should()
                .Be(list[index]);
        }

        [Test]
        public void Test_GetOrElse_An_Invalid_Index_In_An_IReadOnlyList()
        {
            IReadOnlyList<char> list = NonEmptyList();

            list.GetOrElse(list.Count, 'z')
                .Should()
                .Be('z');
        }

        [Test]
        public void Test_GetOrElse_In_A_Null_IReadOnlyList() => Null
            .As<IReadOnlyList<char>>()
            .Invoking(l => l.GetOrElse(0, 'z'))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("list"));

        [Test]
        public void Test_GetOrElse_With_A_Function_A_Valid_Index_In_An_IReadOnlyList()
        {
            IReadOnlyList<char> list = NonEmptyList();
            int index = 0;

            list.GetOrElse(index, () => 'z')
                .Should()
                .Be(list[index]);
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_An_Invalid_Index_In_An_IReadOnlyList()
        {
            IReadOnlyList<char> list = NonEmptyList();

            list.GetOrElse(list.Count, () => 'z')
                .Should()
                .Be('z');
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_In_A_Null_IReadOnlyList() => Null
            .As<IReadOnlyList<char>>()
            .Invoking(l => l.GetOrElse(0, () => 'z'))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("list"));

        [Test]
        public void Test_GetOrElse_With_A_Null_Function_In_A_IReadOnlyList()
        {
            IReadOnlyList<char> list = NonEmptyList();

            list
                .Invoking(l => l.GetOrElse(0, null))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("function"));
        }
        #endregion
    }
}
