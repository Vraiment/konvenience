using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konvenience.Enumerables
{
    class IListTests
    {
        private static List<char> SampleList()
            => new List<char> { 'a', 'b', 'c', 'd' };

        #region IList<T>

        #region Get
        [Test]
        public void Test_Get_A_Valid_Index_In_An_IList()
        {
            IList<char> list = SampleList();
            int index = 0;

            list.Get(index)
                .Should()
                .Be(list[index]);
        }

        [Test]
        public void Test_Get_An_Invalid_Index_In_An_IList()
        {
            IList<char> list = SampleList();

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
        #endregion

        #region GetOrElse
        [Test]
        public void Test_GetOrElse_A_Valid_Index_In_An_IList()
        {
            IList<char> list = SampleList();
            int index = 0;

            list.GetOrElse(index, 'z')
                .Should()
                .Be(list[index]);
        }

        [Test]
        public void Test_GetOrElse_An_Invalid_Index_In_An_IList()
        {
            IList<char> list = SampleList();

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
            IList<char> list = SampleList();
            int index = 0;

            list.GetOrElse(index, () => 'z')
                .Should()
                .Be(list[index]);
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_An_Invalid_Index_In_An_IList()
        {
            IList<char> list = SampleList();

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
            IList<char> list = SampleList();

            list
                .Invoking(l => l.GetOrElse(0, null))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("function"));
        }
        #endregion
        
        #endregion

        #region IReadOnlyList<T>

        #region Get
        [Test]
        public void Test_Get_A_Valid_Index_In_An_IReadOnlyList()
        {
            IReadOnlyList<char> list = SampleList();
            int index = 0;

            list.Get(index)
                .Should()
                .Be(list[index]);
        }

        [Test]
        public void Test_Get_An_Invalid_Index_In_An_IReadOnlyList()
        {
            IReadOnlyList<char> list = SampleList();

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
        #endregion

        #region GetOrElse
        [Test]
        public void Test_GetOrElse_A_Valid_Index_In_An_IReadOnlyList()
        {
            IReadOnlyList<char> list = SampleList();
            int index = 0;

            list.GetOrElse(index, 'z')
                .Should()
                .Be(list[index]);
        }

        [Test]
        public void Test_GetOrElse_An_Invalid_Index_In_An_IReadOnlyList()
        {
            IReadOnlyList<char> list = SampleList();

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
            IReadOnlyList<char> list = SampleList();
            int index = 0;

            list.GetOrElse(index, () => 'z')
                .Should()
                .Be(list[index]);
        }

        [Test]
        public void Test_GetOrElse_With_A_Function_An_Invalid_Index_In_An_IReadOnlyList()
        {
            IReadOnlyList<char> list = SampleList();

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
            IReadOnlyList<char> list = SampleList();

            list
                .Invoking(l => l.GetOrElse(0, null))
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("function"));
        }
        #endregion
        
        #endregion
    }
}
