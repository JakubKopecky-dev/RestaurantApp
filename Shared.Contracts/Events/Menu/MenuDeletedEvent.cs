using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Events.Menu
{
    public sealed record MenuDeletedEvent
    {
        public Guid Id { get; init; }
    }
}
