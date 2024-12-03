using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetAllProducts
{
    public record GetAllProductRequest(int? PageNumber = 1, int? PageSize = 10);
    public record GetAllProductResponse(IEnumerable<Product> Products);
    public class GetAllProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetAllProductRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetAllProductQuery>();
                var result = await sender.Send(query);
                var response = result.Adapt<GetAllProductResponse>();
             
                return Results.Ok(response);
            }).WithName("GetAllProduct")
            .Produces<GetAllProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get All Product")
            .WithDescription("Get all product list from database");
        }
    }
}
