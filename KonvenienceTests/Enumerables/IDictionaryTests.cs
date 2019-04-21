using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

using static NUnit.Framework.Assert;

namespace Konvenience.Enumerables
{
    class IDictionaryTests
    {
        private static Dictionary<string, int> SampleDictionary() => new Dictionary<string, int>
        {
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3
        };

        #region ForEach with IDictionary<TKey, TValue> tests
        [Test]
        public void Test_ForEach_In_An_IDictionary()
        {
            IDictionary<string, int> expected = SampleDictionary();
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
            IDictionary<string, int> dictionary = SampleDictionary();

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
            IReadOnlyDictionary<string, int> expected = SampleDictionary();
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
            IReadOnlyDictionary<string, int> dictionary = SampleDictionary();

            dictionary
                .Invoking(d => d.ForEach(null))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("action"));
        }
        #endregion
    }
}
