using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Query.Domain.Models
{
    public class Menu
    {
        public Guid Id { get; set; }

        public string RestaurantName { get; set; } = "";
        public ICollection<MenuItem> Items { get; set; } = [];

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
