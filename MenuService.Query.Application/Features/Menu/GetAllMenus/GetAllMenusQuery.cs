using MenuService.Query.Application.Abstraction.Messaging;
using MenuService.Query.Application.DTOs.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.Features.Menu.GetAllMenus
{
    public sealed record GetAllMenusQuery() : IQuery<IReadOnlyList<MenuDto>>;

}
