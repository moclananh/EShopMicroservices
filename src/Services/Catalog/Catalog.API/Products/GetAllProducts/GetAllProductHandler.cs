namespace Catalog.API.Products.GetAllProducts
{
    public record GetAllProductQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetAllProductResult>;
    public record GetAllProductResult(IEnumerable<Product> Products);
    public class GetAllProductQueryHandler(IDocumentSession session) 
        : IQueryHandler<GetAllProductQuery, GetAllProductResult>
    {
        public async Task<GetAllProductResult> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToPagedListAsync(
                query.PageNumber ?? 1,
                query.PageSize ?? 10,
                cancellationToken);

            return new GetAllProductResult(products);
        }
    }
}
