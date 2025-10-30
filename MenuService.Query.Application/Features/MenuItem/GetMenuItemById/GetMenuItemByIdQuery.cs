using MenuService.Query.Application.Abstraction.Messaging;
using MenuService.Query.Application.DTOs.MenuItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.Features.MenuItem.GetMenuItemById
{
    public sealed record GetMenuItemByIdQuery(Guid Id) : IQuery<MenuItemDto?>;

}
