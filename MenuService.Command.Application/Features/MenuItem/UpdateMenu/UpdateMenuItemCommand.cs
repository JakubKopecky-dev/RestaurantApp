using MenuService.Command.Application.Abstraction.Messaging;
using MenuService.Command.Application.DTOs.MenuItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Features.MenuItem.UpdateMenu
{
    public sealed record UpdateMenuItemCommand(Guid MenuItemId, CreateUpdateMenuItemDto CreateUpdateMenuItemDto) : ICommand<MenuItemDto>;
 
}
