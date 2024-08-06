namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);

public record GetOrdersByNameQuery(string Name) : IQuery<GetOrdersByNameResult>;