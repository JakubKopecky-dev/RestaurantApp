using MassTransit;
using MassTransit.Transports;
using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.Menu;
using MenuService.Command.Application.Interfaces.Repositories;
using Shared.Contracts.Events.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Features.Menu.UpdateMenu
{
    public sealed class UpdateMenuHandler(IMenuRepository menuRepository, IPublishEndpoint publishEndpoint) : ICommandHandler<UpdateMenuCommand,MenuDto?>
    {
        private readonly IMenuRepository _menuRepository = menuRepository;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;




        public async Task<MenuDto?> Handle(UpdateMenuCommand command, CancellationToken ct)
        {
            Guid menuId = command.MenuId;
            CreateUpdateMenuDto updateMenuDto = command.UpdateDto;

            Domain.Entity.Menu? menu = await _menuRepository.FindByIdAsync(menuId, ct);
            if(menu is null)
                return null;


            menu.RestaurantName = updateMenuDto.RestaurantName;
            menu.UpdatedAt = DateTime.UtcNow;

            await _menuRepository.SaveChangesAsync(ct);

            MenuUpdatedEvent menuUpdatedEvent = new() { Id = menu.Id, RestaurantName = menu.RestaurantName, UpdatedAt = menu.UpdatedAt };
            await _publishEndpoint.Publish(menuUpdatedEvent, ct);

            return new() { Id = menu.Id, RestaurantName = menu.RestaurantName , CreatedAt = menu.CreatedAt, UpdatedAt = menu.UpdatedAt};
        }




    }
}
