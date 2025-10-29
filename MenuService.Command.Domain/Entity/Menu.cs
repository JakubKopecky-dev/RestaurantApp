using MenuService.Command.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Domain.Entity
{
    public class Menu : BaseEntity
    {
        public string RestaurantName { get; set; } = "";
        public ICollection<MenuItem> Items { get; set; } = [];


    }
}
