using Marketplace.SharedKernel.Domain;
using Marketplace.SharedKernel.Domain.Domain;

namespace Marketplace.Modules.ItemListings.Domain.Entities.Items;

public class Item : Entity, IAggregateRoot
{
    private Item()
    {
        Id = Guid.NewGuid();
        CreatedAt = SystemClock.Now;
    }

    public Item(
        string title,
        string description,
        decimal price,
        Guid userId) : this()
    {
        UserId = userId;
        Title = title;
        Description = description;
        Price = price;
    }

    public Guid UserId { get; private set; }

    public string Title { get; private set; } = "";

    public string Description { get; private set; } = "";

    public decimal Price { get; private set; } = default;

    public DateTime CreatedAt { get; }
}
