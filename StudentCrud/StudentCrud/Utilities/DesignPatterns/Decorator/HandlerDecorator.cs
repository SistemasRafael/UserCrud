namespace StudentCrud.Utilities.DesignPatterns.Decorator
{
    // Base Decorator
    public abstract class HandlerDecorator : IRequestHandler
    {
        private readonly IRequestHandler _next;

        protected HandlerDecorator(IRequestHandler next)
        {
            _next = next;
        }

        public virtual string Handle(string request)
        {
            return _next.Handle(request);
        }
    }
}
