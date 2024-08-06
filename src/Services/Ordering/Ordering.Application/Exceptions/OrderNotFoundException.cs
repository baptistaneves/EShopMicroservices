namespace Ordering.Application.Exceptions;

public class OrderNotFoundException : NotFoundException
{
    public OrderNotFoundException(string message) : base(message)
    {
    }
}
