using MenuService.Query.Application.Abstraction.Messaging;
using MenuService.Query.Application.DTOs.MenuItems;
using MenuService.Query.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.Features.MenuItem.SearchMenuItemsByTitle
{
    public sealed class SearchMenuItemsByTitleHandler(IMenuItemRepository menuItemRepository) : IQueryHandler<SearchMenuItemsByTitleQuery, IReadOnlyList<MenuItemDto>>
    {
        private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;



        public async Task<IReadOnlyList<MenuItemDto>> Handle(SearchMenuItemsByTitleQuery query, CancellationToken ct)
        {
            var menuItems = await _menuItemRepository.SearchByTitleAsync(query.Title, ct);

            return [.. menuItems.Select(i => new MenuItemDto
            {
                Id = i.Id,
                MenuId = i.MenuId,
                Title = i.Title,
                UnitPrice = i.UnitPrice,
                UpdatedAt = i.UpdatedAt,
                CreatedAt = i.CreatedAt
            })];
        }




    }
}
