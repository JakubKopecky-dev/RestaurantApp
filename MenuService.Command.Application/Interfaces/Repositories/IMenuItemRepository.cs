using MenuService.Command.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Interfaces.Repositories
{
    public interface IMenuItemRepository : IBaseRepository<MenuItem>
    {
    }
}
