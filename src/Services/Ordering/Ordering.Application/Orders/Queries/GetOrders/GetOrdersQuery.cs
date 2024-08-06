namespace Ordering.Application.Orders.Queries.GetOrders;

public record GetOrdersResult(PaginatedResult<OrderDto> Orders);

public record GetOrdersQuery(PaginationRequest PaginationRequest)
    : IQuery<GetOrdersResult>;