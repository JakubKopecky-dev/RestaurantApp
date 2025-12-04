using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Events.MenuItems
{
    public sealed record MenuItemCreatedEvent
    {
        public Guid Id { get; init; }

        public string Title { get; init; } = "";

        public decimal UnitPrice { get; init; }

        public Guid MenuId { get; init; }

        public DateTime CreatedAt { get; init; }
    }
}
