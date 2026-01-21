using AutoMapper;
using Marketplace.Modules.ItemListings.Domain.Entities.Items;

namespace Marketplace.Modules.ItemListings.Application.UseCases.Models;

public class ItemDto
{
    public Guid Id { get; init; }

    public string Title { get; init; } = "";

    public decimal Price { get; init; }

    public DateTime ListedAt { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Item, ItemDto>();
        }
    }
}

