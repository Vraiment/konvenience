namespace Konvenience
{
    static class Null
    {
        public static T As<T>() where T : class
            => null;
    }
}
