using Basket.API.Basket.DeleteBasket;

namespace Basket.API.Validations
{
    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User is required");
        }
    }
}
