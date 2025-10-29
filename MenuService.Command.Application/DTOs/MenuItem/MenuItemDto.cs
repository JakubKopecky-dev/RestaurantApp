using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.DTOs.MenuItem
{
    public sealed record MenuItemDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; } = "";

        public decimal UnitPrice { get; init; }

        public Guid MenuId { get; init; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }


    }
}
