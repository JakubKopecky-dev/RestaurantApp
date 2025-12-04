using MassTransit;
using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.Menu;
using MenuService.Command.Application.Interfaces.Repositories;
using Shared.Contracts.Events.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Features.Menu.CreateMenu
{
    public sealed class CreateMenuHandler(IMenuRepository menuRepository, IPublishEndpoint publishEndpoint) : ICommandHandler<CreateMenuCommand, MenuDto>
    {
        private readonly IMenuRepository _menuRepository = menuRepository;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;



        public async Task<MenuDto> Handle(CreateMenuCommand command, CancellationToken ct)
        {
            CreateUpdateMenuDto createDto = command.CreateUpdateMenuDto;

            Domain.Entity.Menu menu = new()
            {
                Id = Guid.Empty,
                RestaurantName = createDto.RestaurantName,
                CreatedAt = DateTime.UtcNow,
            };


            var createdMenu = await _menuRepository.InsertAsync(menu, ct);

            MenuCreatedEvent menuCreatedEvent = new() { Id = createdMenu.Id, RestaurantName = createdMenu.RestaurantName, CreatedAt = createdMenu.CreatedAt };
            await _publishEndpoint.Publish(menuCreatedEvent, ct);

            return new() { Id = createdMenu.Id, CreatedAt = createdMenu.CreatedAt, RestaurantName = createdMenu.RestaurantName};
        }



    }
}
