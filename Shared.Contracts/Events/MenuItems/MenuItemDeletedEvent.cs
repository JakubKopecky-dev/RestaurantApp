using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Events.MenuItems
{
    public sealed record MenuItemDeletedEvent
    {
        public Guid Id { get; init; }

    }
}
