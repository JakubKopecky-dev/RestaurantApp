using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.Menu;
using MenuService.Command.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Features.Menu.UpdateMenu
{
    public sealed class UpdateMenuHandler(IMenuRepository menuRepository) : ICommandHandler<UpdateMenuCommand,MenuDto?>
    {
        private readonly IMenuRepository _menuRepository = menuRepository;



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

            return new() { Id = menu.Id, RestaurantName = menu.RestaurantName , CreatedAt = menu.CreatedAt, UpdatedAt = menu.UpdatedAt};
        }




    }
}
