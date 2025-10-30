using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Application.DTOs.MenuItems
{
    public sealed record MenuItemDto
    {
        public Guid Id { get; init; }

        public string Title { get; init; } = "";

        public decimal UnitPrice { get; init; }

        public Guid MenuId { get; init; }

        public DateTime CreatedAt { get; init; }

        public DateTime? UpdatedAt { get; init; }
    }
}
