namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(
      Guid Id,
      string Name,
      string Description,
      string ImageFile,
      decimal Price,
      List<string> Category);
    public record UpdateProductResponse(bool IsSuccess);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateProductResponse>();
                if (response.IsSuccess == false) {
                    return Results.BadRequest("Update product failed: Product not exist!");
                }
                return Results.Ok(response);
            }).WithName("UpdateProduct")
            .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Product")
            .WithDescription("Update Product in database");
        }
    }
}
