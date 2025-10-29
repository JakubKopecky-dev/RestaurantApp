using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.Menu;
using MenuService.Command.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Features.Menu.CreateMenu
{
    public sealed class CreateMenuHandler(IMenuRepository menuRepository) : ICommandHandler<CreateMenuCommand, MenuDto>
    {
        private readonly IMenuRepository _menuRepository = menuRepository;



        public async Task<MenuDto> Handle(CreateMenuCommand command, CancellationToken ct)
        {
            CreateUpdateMenuDto createDto = command.CreateUpdateMenuDto;

            Domain.Entity.Menu menu = new()
            {
                Id = Guid.Empty,
                RestaurantName = createDto.RestaurantName,
                CreatedAt = DateTime.UtcNow,
            };


            Domain.Entity.Menu createdMenu = await _menuRepository.InsertAsync(menu, ct);

            return new() { Id = createdMenu.Id, CreatedAt = createdMenu.CreatedAt, RestaurantName = createdMenu.RestaurantName};
        }



    }
}
