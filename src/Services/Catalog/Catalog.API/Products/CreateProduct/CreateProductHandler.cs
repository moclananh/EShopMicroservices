using MediatR;
using System.Reflection.Metadata;

namespace Catalog.API.Products.CreateProduct
{
    /* Applying CQRS and MediatR */
    public record CreateProductCommand(
        string Name,
        string Description,
        string ImageFile,
        decimal Price,
        List<string> Category
        ): IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
