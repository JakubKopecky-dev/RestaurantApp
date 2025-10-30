using MenuService.Query.Application.Abstraction.Messaging;
using MenuService.Query.Application.DTOs.MenuItems;
using MenuService.Query.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.Features.MenuItem.GetMenuItemById
{
    public sealed class GetMenuItemByIdHandler(IMenuItemRepository menuItemRepository) : IQueryHandler<GetMenuItemByIdQuery, MenuItemDto?>
    {
        private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;



        public async Task<MenuItemDto?> Handle(GetMenuItemByIdQuery query, CancellationToken ct)
        {
            var menu = await _menuItemRepository.FindByIdAsync(query.Id, ct);
            if (menu is null)
                return null;

            return new() 
            { 
                Id = menu.Id,
                Title = menu.Title,
                MenuId = menu.MenuId,
                UnitPrice = menu.UnitPrice,
                CreatedAt = menu.CreatedAt,
                UpdatedAt = menu.UpdatedAt,
            };
        }



    }
}
