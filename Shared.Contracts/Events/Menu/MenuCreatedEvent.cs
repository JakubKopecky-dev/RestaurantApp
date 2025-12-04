using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Events.Menu
{
    public sealed record MenuCreatedEvent
    {
        public Guid Id { get; init; }
        public string RestaurantName { get; init; } = "";

        public DateTime CreatedAt { get; init; }

    }
}
