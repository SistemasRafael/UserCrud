namespace StudentCrud.Utilities.DesignPatterns.Decorator.Decorators
{
    public class FieldRequiredDecorator : HandlerDecorator
    {
        public FieldRequiredDecorator(IRequestHandler next) : base(next) { }

        public override string Handle(string request)
        {
            if (string.IsNullOrWhiteSpace(request))
            {
                return "This field is required";
            }

            return base.Handle(request);
        }
    }
}
