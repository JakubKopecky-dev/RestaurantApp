using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.MenuItem;
using MenuService.Command.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Features.MenuItem.CreateMenuItem
{
    public sealed class CreateMenuItemHandler(IMenuItemRepository menuItemRepository) : ICommandHandler<CreateMenuItemCommand, MenuItemDto>
    {
        private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;



        public async Task<MenuItemDto> Handle(CreateMenuItemCommand command, CancellationToken ct)
        {
            CreateUpdateMenuItemDto createDto = command.CreateMenuItemDto;

            Domain.Entity.MenuItem menuItem = new() { MenuId = createDto.MenuId, Id = Guid.Empty, Title = createDto.Title, UnitPrice = createDto.UnitPrice, CreatedAt = DateTime.UtcNow };

            Domain.Entity.MenuItem createdMenuItem = await _menuItemRepository.InsertAsync(menuItem, ct);

            return new()
            {
                Id = createdMenuItem.Id,
                Title = createdMenuItem.Title,
                UnitPrice = createdMenuItem.UnitPrice,
                MenuId = createdMenuItem.MenuId,
                CreatedAt = createdMenuItem.CreatedAt
            };
        }





    }
}
