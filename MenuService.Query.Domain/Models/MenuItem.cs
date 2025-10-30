using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Domain.Models
{
    public class MenuItem
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = "";

        public decimal UnitPrice { get; set; }

        public Guid MenuId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
