namespace Konvenience
{
    public class DummyClass
    {
        public bool Configured { get; private set; } = false;

        public void Configure() => Configured = true;
    }
}
