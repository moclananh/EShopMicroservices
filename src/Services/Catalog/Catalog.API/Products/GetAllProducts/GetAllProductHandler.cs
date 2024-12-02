
namespace Catalog.API.Products.GetAllProducts
{
    public record GetAllProductQuery() : IQuery<GetAllProductResult>;
    public record GetAllProductResult(IEnumerable<Product> Products);
    public class GetAllProductQueryHandler(IDocumentSession session) 
        : IQueryHandler<GetAllProductQuery, GetAllProductResult>
    {
        public async Task<GetAllProductResult> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetAllProductResult(products);
        }
    }
}
