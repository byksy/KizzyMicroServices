using Microsoft.EntityFrameworkCore;

namespace FreeCourse.Services.Order.Infrastructure;

public class OrderDbContext : DbContext
{
    public const string DEFAULT_SCHEMA = "ordering";

    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
        
    }
    public DbSet<Domain.OrderAggregate.Order> Orders { get; set; }
    public DbSet<Domain.OrderAggregate.OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.OrderAggregate.Order>().ToTable("orders", DEFAULT_SCHEMA);
        modelBuilder.Entity<Domain.OrderAggregate.OrderItem>().ToTable("order_items", DEFAULT_SCHEMA);

        modelBuilder.Entity<Domain.OrderAggregate.OrderItem>().Property(o => o.Price).HasColumnType("decimal(18,2");
        modelBuilder.Entity<Domain.OrderAggregate.Order>().OwnsOne(o => o.Address).WithOwner();
        base.OnModelCreating(modelBuilder);
    }
}