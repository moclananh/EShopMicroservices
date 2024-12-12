
using BuildingBlocks.Messaging.Events;
using Mapster;

namespace Basket.API.Basket.CheckoutBasket
{
    public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketResult>;
    public record CheckoutBasketResult(bool IsSuccess);
    public class CheckoutBasketCommandHandler(IBasketRepository repository, IPublishEndpoint publishEndpoint)
        : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
    {
        public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
        {
            var basket = await repository.GetBasket(command.BasketCheckoutDto.UserName, cancellationToken);
            if (basket == null) 
            {
                return new CheckoutBasketResult(false); 
            }

            var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
            eventMessage.TotalPrice = basket.TotalPrice;

            //send basket checkout event to rabbitMQ using masstransit
            await publishEndpoint.Publish(eventMessage, cancellationToken);
            //delete the basket
            await repository.DeleteBasket(command.BasketCheckoutDto.UserName, cancellationToken);

            return new CheckoutBasketResult(true);
        }
    }
}
