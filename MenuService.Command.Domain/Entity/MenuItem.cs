using MenuService.Command.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Domain.Entity
{
    public class MenuItem : BaseEntity
    {

        public string Title { get; set; } = "";

        public decimal UnitPrice { get; set; }

        public Guid MenuId { get; set; } 


    }
}
