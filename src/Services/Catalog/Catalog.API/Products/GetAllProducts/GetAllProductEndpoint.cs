using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetAllProducts
{
    public record GetAllProductResponse(IEnumerable<Product> Products);
    public class GetAllProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetAllProductQuery());
                var response = result.Adapt<GetAllProductResponse>();
                if (response.Products.Count() <= 0)
                {
                    return Results.NoContent();
                }
                return Results.Ok(response);
            }).WithName("GetAllProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get All Product")
            .WithDescription("Get all product list from database");
        }
    }
}
