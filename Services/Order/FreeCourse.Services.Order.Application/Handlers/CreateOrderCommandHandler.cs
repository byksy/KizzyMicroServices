using FreeCourse.Services.Order.Application.Commands;
using FreeCourse.Services.Order.Application.Dtos;
using FreeCourse.Services.Order.Domain.OrderAggregate;
using FreeCourse.Services.Order.Infrastructure;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace FreeCourse.Services.Order.Application.Handlers;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
{
    private readonly OrderDbContext _context;

    public CreateOrderCommandHandler(OrderDbContext context)
    {
        _context = context;
    }
    public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var newAddress = new Address(request.Address.Province, request.Address.District, request.Address.Street, request.Address.ZipCode, request.Address.Line);

        var newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);

        request.OrderItems.ForEach(dto =>
        {
            newOrder.AddOrderItem(dto.ProductId, dto.ProductName, dto.Price, dto.PictureUrl);
        });

        await _context.Orders.AddAsync(newOrder, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Response<CreatedOrderDto>.Success(new CreatedOrderDto{OrderId = newOrder.Id},201);
    }
}