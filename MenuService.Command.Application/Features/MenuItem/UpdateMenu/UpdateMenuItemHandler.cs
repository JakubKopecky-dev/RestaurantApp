using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.MenuItem;
using MenuService.Command.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Features.MenuItem.UpdateMenu
{
    public sealed class UpdateMenuItemHandler(IMenuItemRepository menuItemRepository) : ICommandHandler<UpdateMenuItemCommand, MenuItemDto?>
    {
        private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;



        public async Task<MenuItemDto?> Handle(UpdateMenuItemCommand command, CancellationToken ct)
        {
            Guid menuItemId = command.MenuItemId;
            CreateUpdateMenuItemDto updateDto = command.CreateUpdateMenuItemDto;


            Domain.Entity.MenuItem? menuItem = await _menuItemRepository.FindByIdAsync(menuItemId, ct);
            if (menuItem is null)
                return null;

            menuItem.Title = updateDto.Title;
            menuItem.UnitPrice = updateDto.UnitPrice;
            menuItem.MenuId = updateDto.MenuId;
            menuItem.UpdatedAt = DateTime.UtcNow;

            await _menuItemRepository.SaveChangesAsync(ct);

            return new()
            {
                Id = menuItem.Id,
                Title = menuItem.Title,
                MenuId = menuItem.MenuId,
                UpdatedAt = menuItem.UpdatedAt,
                CreatedAt = menuItem.CreatedAt,
                UnitPrice = menuItem.UnitPrice
            };

        }



    }
}
