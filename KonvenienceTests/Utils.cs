using System.Collections;
using System.Collections.Generic;

namespace Konvenience
{
    static class Null
    {
        public static T As<T>() where T : class
            => null;
    }

    static class Enumerable
    {
        public static IEnumerable<T> For<T>(params T[] objects)
            => new SampleEnumerable<T>(objects);

        private class SampleEnumerable<T> : IEnumerable<T>
        {
            private readonly T[] objects;

            public SampleEnumerable(params T[] objects)
            {
                this.objects = new T[objects.Length];
                objects.CopyTo(this.objects, 0);
            }

            public IEnumerator<T> GetEnumerator()
            {
                foreach (var obj in objects)
                {
                    yield return obj;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();
        }
    }
}
