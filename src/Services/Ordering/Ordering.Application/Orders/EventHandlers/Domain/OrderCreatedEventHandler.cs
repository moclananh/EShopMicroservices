namespace Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderCreatedEventHandler(IPublishEndpoint publishEndpoint, IFeatureManager featureManager, ILogger<OrderCreatedEventHandler> logger)
        : INotificationHandler<OrderCreatedEvent>
    {
        public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handler: {DomainEvent}", domainEvent.GetType().Name);
            if (await featureManager.IsEnabledAsync("OrderFullfilment"))
            {
                var orderCreatedIntergrationEvent = domainEvent.order.ToOrderDto();
                await publishEndpoint.Publish(orderCreatedIntergrationEvent, cancellationToken);
            }
        }
    }
}
