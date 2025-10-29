using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.DTOs.MenuItem
{
    public sealed record CreateUpdateMenuItemDto
    {
        public string Title { get; init; } = "";

        public decimal UnitPrice { get; init; }

        public Guid MenuId { get; init; }
    }
}
