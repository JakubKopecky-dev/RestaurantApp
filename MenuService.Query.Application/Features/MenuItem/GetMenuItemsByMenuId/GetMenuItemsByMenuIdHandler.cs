using MenuService.Query.Application.Abstraction.Messaging;
using MenuService.Query.Application.DTOs.MenuItems;
using MenuService.Query.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.Features.MenuItem.GetMenuItemsByMenuId
{
    public class GetMenuItemsByMenuIdHandler(IMenuItemRepository menuItemRepository) : IQueryHandler<GetMenuItemsByMenuIdQuery,IReadOnlyList<MenuItemDto>>
    {
        private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;



        public async Task<IReadOnlyList<MenuItemDto>> Handle(GetMenuItemsByMenuIdQuery query, CancellationToken ct)
        {
            var menuItems = await _menuItemRepository.GetMenuItemsByMenuIdAsync(query.MenuId,ct);

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
