using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konvenience.Enumerables
{
    class ICollectionTests
    {
        private static List<char> SampleList()
            => new List<char> { 'a', 'b', 'c', 'd' };

        #region ICollection<T>

        #region IsEmpty/IsNotEmpty
        [Test]
        public void Test_Emptiness_Of_A_Non_Empty_ICollection()
        {
            ICollection<char> collection = SampleList();

            collection.IsEmpty().Should().BeFalse();
            collection.IsNotEmpty().Should().BeTrue();
        }

        [Test]
        public void Test_Emptiness_Of_An_Empty_ICollection()
        {
            ICollection<char> collection = new List<char>();

            collection.IsEmpty().Should().BeTrue();
            collection.IsNotEmpty().Should().BeFalse();
        }

        [Test]
        public void Test_Emptiness_Of_A_Null_ICollection()
        {
            ICollection<char> collection = null;

            collection
                .Invoking(a => a.IsEmpty())
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("collection"));

            collection
                .Invoking(a => a.IsNotEmpty())
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("collection"));
        }
        #endregion

        #endregion

        #region IReadOnlyCollection<T>

        #region IsEmpty/IsNotEmpty
        [Test]
        public void Test_Emptiness_Of_A_Non_Empty_IReadOnlyCollection()
        {
            ICollection<char> collection = SampleList();

            collection.IsEmpty().Should().BeFalse();
            collection.IsNotEmpty().Should().BeTrue();
        }

        [Test]
        public void Test_Emptiness_Of_An_Empty_IReadOnlyCollection()
        {
            ICollection<char> collection = new List<char>();

            collection.IsEmpty().Should().BeTrue();
            collection.IsNotEmpty().Should().BeFalse();
        }

        [Test]
        public void Test_Emptiness_Of_A_Null_IReadOnlyCollection()
        {
            ICollection<char> collection = null;

            collection
                .Invoking(a => a.IsEmpty())
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("collection"));

            collection
                .Invoking(a => a.IsNotEmpty())
                .Should()
                .Throw<ArgumentNullException>()
                .Where(e => e.Message.Contains("collection"));
        }
        #endregion

        #endregion
    }
}
