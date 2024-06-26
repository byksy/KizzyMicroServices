namespace FreeCourse.Services.Basket.Dtos;

public class BasketDto
{
    public string UserId { get; set; } = null!;
    public string? DiscountCode { get; set; }
    public List<BasketItemDto> BasketItems { get; set; } = null!;

    public decimal TotalPrice
    {
        get => BasketItems.Sum(b => b.Price * b.Quantity);
    }
}