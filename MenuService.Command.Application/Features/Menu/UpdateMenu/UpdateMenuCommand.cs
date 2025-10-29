using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Features.Menu.UpdateMenu
{
    public sealed record UpdateMenuCommand(Guid MenuId, CreateUpdateMenuDto UpdateDto) : ICommand<MenuDto?>
    {
    }
}
