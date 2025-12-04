using MassTransit;
using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.MenuItem;
using MenuService.Command.Application.Interfaces.Repositories;
using Shared.Contracts.Events.MenuItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Features.MenuItem.CreateMenuItem
{
    public sealed class CreateMenuItemHandler(IMenuItemRepository menuItemRepository, IPublishEndpoint publishEndpoint) : ICommandHandler<CreateMenuItemCommand, MenuItemDto>
    {
        private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;



        public async Task<MenuItemDto> Handle(CreateMenuItemCommand command, CancellationToken ct)
        {
            CreateUpdateMenuItemDto createDto = command.CreateMenuItemDto;

            Domain.Entity.MenuItem menuItem = new() { MenuId = createDto.MenuId, Id = Guid.Empty, Title = createDto.Title, UnitPrice = createDto.UnitPrice, CreatedAt = DateTime.UtcNow };

            var createdMenuItem = await _menuItemRepository.InsertAsync(menuItem, ct);

            MenuItemCreatedEvent menuItemCreatedEvent = new()
            {
                Id = createdMenuItem.Id,
                Title = createdMenuItem.Title,
                UnitPrice = createdMenuItem.UnitPrice,
                CreatedAt = DateTime.UtcNow,
                MenuId = createDto.MenuId
            };
            await _publishEndpoint.Publish(menuItemCreatedEvent, ct);

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
