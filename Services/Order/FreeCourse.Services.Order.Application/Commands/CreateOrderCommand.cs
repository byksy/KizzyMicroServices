using FreeCourse.Services.Order.Application.Dtos;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace FreeCourse.Services.Order.Application.Commands;

public class CreateOrderCommand : IRequest<Response<CreatedOrderDto>>
{
    public string BuyerId { get; set; } = null!;
    public AddressDto Address { get; set; } = null!;
    public List<OrderItemDto> OrderItems { get; set; } = null!;
}