
using BuidingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetAllOrder
{
    public class GetAllOrderHandler(IApplicationDbContext dbContext) : IQueryHandler<GetAllOrderQuery, GetAllOrderResult>
    {
        public async Task<GetAllOrderResult> Handle(GetAllOrderQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);
            var orders = await dbContext.Orders
                .Include(o => o.OrderItems)
                .OrderBy(o => o.OrderName.Value)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new GetAllOrderResult(new PaginatedResult<OrderDto>(
                pageIndex,
                pageSize,
                totalCount,
                orders.ToOrderDtoList()));
        }
    }
}
