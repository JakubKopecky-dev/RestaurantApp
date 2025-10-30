using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.DTOs.Menu
{
    public sealed record MenuDto
    {
        public Guid Id { get; set; }

        public string RestaurantName { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
