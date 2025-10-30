using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.Menu;
using MenuService.Command.Application.DTOs.MenuItem;
using MenuService.Command.Application.Features.Menu.CreateMenu;
using MenuService.Command.Application.Features.Menu.DeleteMenu;
using MenuService.Command.Application.Features.Menu.UpdateMenu;
using MenuService.Command.Application.Features.MenuItem.CreateMenuItem;
using MenuService.Command.Application.Features.MenuItem.DeleteMenuItem;
using MenuService.Command.Application.Features.MenuItem.UpdateMenu;

namespace MenuService.Command.Api.GraphQL
{
    public class Mutation(ICommandExecutor executor)
    {
        private readonly ICommandExecutor _executor = executor;


        public async Task<MenuDto> CreateMenu(CreateUpdateMenuDto input, CancellationToken ct)
        {
            CreateMenuCommand command = new(input);

            return await _executor.Execute<CreateMenuCommand, MenuDto>(command, ct);
        }



        public async Task<MenuDto?> UpdateMenu(Guid id, CreateUpdateMenuDto input, CancellationToken ct)
        {
            UpdateMenuCommand command = new(id, input);

            return await _executor.Execute<UpdateMenuCommand, MenuDto?>(command, ct);
        }



        public async Task<MenuDto?> DeleteMenu(Guid id, CancellationToken ct)
        {
            DeleteMenuCommand command = new(id);

            return await _executor.Execute<DeleteMenuCommand, MenuDto?>(command, ct);
        }



        public async Task<MenuItemDto> CreateMenuItem(CreateUpdateMenuItemDto input, CancellationToken ct)
        {
            CreateMenuItemCommand command = new(input);

            return await _executor.Execute<CreateMenuItemCommand,MenuItemDto>(command, ct);
        }



        public async Task<MenuItemDto?> UpdateMenuItem(Guid id, CreateUpdateMenuItemDto input, CancellationToken ct)
        {
            UpdateMenuItemCommand command = new(id, input);

            return await _executor.Execute<UpdateMenuItemCommand, MenuItemDto?>(command, ct);
        }



        public async Task<MenuItemDto?> DeleteMenuItem(Guid id, CancellationToken ct)
        {
            DeleteMenuItemCommand command = new(id);

            return await _executor.Execute<DeleteMenuItemCommand, MenuItemDto?>(command, ct);
        }





    }
}
