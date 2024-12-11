namespace Ordering.Application.Orders.Queries.GetOrdersByName
{
    public record GetOrdersByNameQuery(string Name) : IQuery<GetOrderByNameResult>;
    public record GetOrderByNameResult(IEnumerable<OrderDto> Orders);
}
