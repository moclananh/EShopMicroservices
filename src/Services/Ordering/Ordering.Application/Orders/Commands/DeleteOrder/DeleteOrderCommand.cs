namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    public record DeleteOrderCommand(Guid OrderId) : ICommand<DeleteOrderResult>;
    public record DeleteOrderResult(bool IsSuccess);
}
