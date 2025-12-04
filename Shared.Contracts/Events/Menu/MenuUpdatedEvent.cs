using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Events.Menu
{
    public sealed record MenuUpdatedEvent
    {
        public Guid Id { get; init; }
        public string RestaurantName { get; init; } = "";

        public DateTime? UpdatedAt { get; init; }
    }
}
