using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Features.Menu.DeleteMenu
{
    public sealed record DeleteMenuCommand(Guid MenuId) : ICommand<MenuDto?>;

}
