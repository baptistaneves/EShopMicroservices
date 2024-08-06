namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public record GetOrdersByCustomerResult(IEnumerable<OrderDto> OrderDtos);
public record GetOrdersByCustomerQuery(Guid CustomerId) 
    : IQuery<GetOrdersByCustomerResult>;