using MenuService.Query.Application.Abstraction.Messaging;
using MenuService.Query.Application.DTOs.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.Features.Menu.SearchMenusByRestaurantName
{
    public sealed record SearchMenusByRestaurantNameQuery(string RestaurantName) : IQuery<IReadOnlyList<MenuDto>>;

}
