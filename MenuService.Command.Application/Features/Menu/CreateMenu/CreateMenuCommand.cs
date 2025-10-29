using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.Menu;


namespace MenuService.Command.Application.Features.Menu.CreateMenu
{
    public sealed record CreateMenuCommand(CreateUpdateMenuDto CreateUpdateMenuDto) : ICommand<MenuDto>;
    
    
}
