using BuidingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetAllOrder
{
    public record GetAllOrderQuery(PaginationRequest PaginationRequest) :IQuery<GetAllOrderResult;
    public record GetAllOrderResult(PaginatedResult<OrderDto> Orders);

}
