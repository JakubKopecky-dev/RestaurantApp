using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.Menu;
using MenuService.Command.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Features.Menu.DeleteMenu
{
    public sealed class DeleteMenuHandler(IMenuRepository menuRepository) : ICommandHandler<DeleteMenuCommand,MenuDto?>
    {
        private readonly IMenuRepository _menuRepository = menuRepository;


        public async Task<MenuDto?> Handle(DeleteMenuCommand command, CancellationToken ct)
        {
            Guid menuId = command.MenuId;

            Domain.Entity.Menu? menu = await _menuRepository.FindByIdAsync(menuId, ct);
            if(menu is null)
                return null;

            MenuDto deletedMenu = new() { Id = menu.Id, RestaurantName = menu.RestaurantName, CreatedAt = menu.CreatedAt, UpdatedAt = menu.UpdatedAt};

            _menuRepository.Remove(menu);
            await _menuRepository.SaveChangesAsync(ct);

            return deletedMenu;
        }





    }
}
