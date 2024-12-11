using BuidingBlocks.CQRS;
using Ordering.Application.DTOs;

namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;
    public record CreateOrderResult(Guid Id);
}
