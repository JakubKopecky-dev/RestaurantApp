using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.MenuItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Features.MenuItem.CreateMenuItem
{
    public sealed record CreateMenuItemCommand(CreateUpdateMenuItemDto CreateMenuItemDto) : ICommand<MenuItemDto>;

}
