
using Ordering.Application.Orders.Queries.GetAllOrder;

namespace Ordering.API.Endpoints
{
    public record GetAllOrderResponse(PaginatedResult<OrderDto> Orders);
    public class GetAllOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders", async ([AsParameters] PaginationRequest request, ISender sender) => {
                var result = await sender.Send(new GetAllOrderQuery(request));
                var response = result.Adapt<GetAllOrderResponse>();

                return Results.Ok(response);
            }).WithName("GetAllOrder")
            .Produces<GetAllOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get All Order")
            .WithDescription("Get All Order");
        }
    }
}
