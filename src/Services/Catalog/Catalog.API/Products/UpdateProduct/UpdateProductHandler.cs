using Catalog.API.Products.CreateProduct;
using Catalog.API.Products.GetAllProducts;

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(
        Guid Id,
        string Name,
        string Description,
        string ImageFile,
        decimal Price,
        List<string> Category
        ) : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);
    public class UpdateProductCommandHandler
        (IDocumentSession session, ILogger<GetAllProductQueryHandler> logger)
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductCommandHandler.Handler call with {@query}", command);
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
            if (product == null)
            {
                return new UpdateProductResult(false);
            }
            product.Name = command.Name;
            product.Description = command.Description;
            product.Price = command.Price;
            product.Category = command.Category;
            product.ImageFile = command.ImageFile;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);
            return new UpdateProductResult(true);
        }
    }
}
