namespace StudentCrud.Utilities.DesignPatterns.Decorator
{
    public class ConcreteHandler : IRequestHandler
    {
        // Concrete Component
        public string Handle(string request)
        {
            return string.Empty;
        }
    }
}
