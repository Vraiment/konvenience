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

        private static Dictionary<string, int> NonEmptyDictionary() => new Dictionary<string, int>
        {
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3
        };

        #region ForEach with IDictionary<TKey, TValue> tests
        [Test]
        public void Test_ForEach_In_An_IDictionary()
        {
            IDictionary<string, int> expected = NonEmptyDictionary();
            Dictionary<string, int> result = new Dictionary<string, int>();

            expected.ForEach((k, v) =>
            {
                result.Should().NotContainKey(k, "Duplicate key/value pair iteration");
                result[k] = v;
            });

            result.Should().Equal(expected);
        }

        [Test]
        public void Test_ForEach_In_A_Null_IDictionary() => Null
            .As<IDictionary<string, int>>()
            .Invoking(d => d.ForEach((k, v) => Fail("This should never be executed")))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("dictionary"));

        [Test]
        public void Test_ForEach_In_An_IDictionary_With_A_Null_Action()
        {
            IDictionary<string, int> dictionary = NonEmptyDictionary();

            dictionary
                .Invoking(d => d.ForEach(null))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("action"));
        }
        #endregion

        #region ForEach with IReadOnlyDictionary<TKey, TValue> tests
        [Test]
        public void Test_ForEach_In_An_IReadOnlyDictionary()
        {
            IReadOnlyDictionary<string, int> expected = NonEmptyDictionary();
            Dictionary<string, int> result = new Dictionary<string, int>();

            expected.ForEach((k, v) =>
            {
                result.Should().NotContainKey(k, "Duplicate key/value pair iteration");
                result[k] = v;
            });

            (result as IReadOnlyDictionary<string, int>).Should().Equal(expected);
        }

        [Test]
        public void Test_ForEach_In_A_Null_IReadOnlyDictionary() => Null
            .As<IReadOnlyDictionary<string, int>>()
            .Invoking(d => d.ForEach((k, v) => Fail("This should never be executed")))
            .Should()
            .Throw<ArgumentNullException>()
            .Where(e => e.Message.Contains("dictionary"));

        [Test]
        public void Test_ForEach_In_An_IReadOnlyDictionary_With_A_Null_Action()
        {
            IReadOnlyDictionary<string, int> dictionary = NonEmptyDictionary();

            dictionary
                .Invoking(d => d.ForEach(null))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("action"));
        }
        #endregion
    }
}
