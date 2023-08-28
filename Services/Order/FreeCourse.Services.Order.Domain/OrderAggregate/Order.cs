using FreeCourse.Services.Order.Domain.Core;

namespace FreeCourse.Services.Order.Domain.OrderAggregate;

public class Order : Entity, IAggregateRoot
{
    public DateTime CreatedDate { get; private set; }
    public Address Address { get; private set; }
    public string BuyerId { get; private set; }
    private readonly List<OrderItem> _orderItems;
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    public Order()
    {
        
    }
    public Order(string buyerId, Address address)
    {
        _orderItems = new List<OrderItem>();
        CreatedDate =DateTime.UtcNow;
        BuyerId = buyerId;
        Address = address;
    }

    public void AddOrderItem(string productId, string productName, decimal price, string pictureUrl)
    {
        var existProduct = _orderItems.Any(o => o.ProductId == productId);
        if (!existProduct)
        {
            var orderItem = new OrderItem(productId, productName, pictureUrl, price);
            _orderItems.Add(orderItem);
        }
    }

    public decimal GetTotalPrice => _orderItems.Sum(o => o.Price);
}