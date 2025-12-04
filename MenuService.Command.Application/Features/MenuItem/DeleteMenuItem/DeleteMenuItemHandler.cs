using MassTransit;
using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.MenuItem;
using MenuService.Command.Application.Interfaces.Repositories;
using Shared.Contracts.Events.MenuItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Features.MenuItem.DeleteMenuItem
{
    public sealed class DeleteMenuItemHandler(IMenuItemRepository menuItemRepository, IPublishEndpoint publishEndpoint) : ICommandHandler<DeleteMenuItemCommand, MenuItemDto?>
    {
        private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;



        public async Task<MenuItemDto?> Handle(DeleteMenuItemCommand command, CancellationToken ct)
        {
            Domain.Entity.MenuItem? menuItem = await _menuItemRepository.FindByIdAsync(command.MenuItemId, ct);
            if (menuItem is null)
                return null;

            MenuItemDto deletedMenuItem = new()
            {
                Id = menuItem.Id,
                Title = menuItem.Title,
                CreatedAt = menuItem.CreatedAt,
                MenuId = menuItem.MenuId,
                UnitPrice = menuItem.UnitPrice,
                UpdatedAt = menuItem.UpdatedAt,
            };

            _menuItemRepository.Remove(menuItem);
            await _menuItemRepository.SaveChangesAsync(ct);

            MenuItemDeletedEvent menuItemDeletedEvent = new() { Id = menuItem.Id };
            await _publishEndpoint.Publish(menuItemDeletedEvent, ct);

            return deletedMenuItem;
        }




    }
}
