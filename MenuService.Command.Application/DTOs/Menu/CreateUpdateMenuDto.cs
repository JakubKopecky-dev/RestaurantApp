using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.DTOs.Menu
{
    public sealed record  CreateUpdateMenuDto
    {
        public string RestaurantName { get; init; } = "";

    }
}
