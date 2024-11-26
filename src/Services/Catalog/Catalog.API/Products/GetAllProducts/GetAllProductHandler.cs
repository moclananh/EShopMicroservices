
namespace Catalog.API.Products.GetAllProducts
{
    public record GetAllProductQuery() : IQuery<GetAllProductResult>;
    public record GetAllProductResult(IEnumerable<Product> Products);
    public class GetAllProductQueryHandler(IDocumentSession session, ILogger<GetAllProductQueryHandler> logger) 
        : IQueryHandler<GetAllProductQuery, GetAllProductResult>
    {
        public async Task<GetAllProductResult> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetAllProductQueryHandler.Handler call with {@query}", query);
            var products = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetAllProductResult(products);
        }
    }
}
