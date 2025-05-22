namespace StudentCrud.Utilities.DesignPatterns.Decorator.Decorators
{
    public class MaxLengthDecorator : HandlerDecorator
    {
        private int _maxLength = 0;

        public MaxLengthDecorator(IRequestHandler next, int maxLength) : base(next) 
        {
            _maxLength = maxLength;
        }

        public override string Handle(string request)
        {
            if (request.Length > _maxLength)
            {
                return $"The value should be less than {_maxLength}";
            }

            return base.Handle(request);
        }
    }
}
