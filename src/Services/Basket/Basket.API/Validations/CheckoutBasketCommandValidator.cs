using Basket.API.Basket.CheckoutBasket;

namespace Basket.API.Validations
{
    public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommand>
    {
        public CheckoutBasketCommandValidator()
        {
            RuleFor(x => x.BasketCheckoutDto).NotNull().WithMessage("BasketCheckoutDto is required");
            RuleFor(x => x.BasketCheckoutDto.UserName).NotEmpty().WithMessage("UserName cannot be empty");
        }
    }
}
