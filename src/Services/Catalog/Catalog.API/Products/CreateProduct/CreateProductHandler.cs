
namespace Catalog.API.Products.CreateProduct
{
    /* Applying CQRS and MediatR */
    public record CreateProductCommand(
        string Name,
        string Description,
        string ImageFile,
        decimal Price,
        List<string> Category
        ): ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // create product entity from command object
            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
                Category = command.Category
            };


            // save changes (using Marten library)
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            // save to database
            return new CreateProductResult(product.Id);
            
        }
    }
}
