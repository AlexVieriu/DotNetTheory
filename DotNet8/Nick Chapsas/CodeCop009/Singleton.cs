namespace CodeCop009;

public sealed class Singleton
{
    private Singleton() { }
    public static Singleton Instance { get; } = new();

    public Guid Id { get; } = Guid.NewGuid();

}

public class SomeClass
{
    public Guid Id { get; } = Guid.NewGuid();
}
