using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.DTOs.Menu
{
    public sealed record MenuDto
    {
        public Guid Id { get; init; }

        public string RestaurantName { get; init; } = "";


        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
