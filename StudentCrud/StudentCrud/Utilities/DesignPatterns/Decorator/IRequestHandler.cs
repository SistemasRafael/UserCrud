namespace StudentCrud.Utilities.DesignPatterns.Decorator
{
    // Base Interface
    public interface IRequestHandler
    {
        string Handle(string request);
    }
}
