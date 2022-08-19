namespace Simple_REST_API.Domain.Responses.Exceptions
{
    public class DomainNotFoundException : Exception
    {
        public DomainNotFoundException(string message) : base(message)
        {
        }
    }
}
