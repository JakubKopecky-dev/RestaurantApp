using MenuService.Command.Application.Interfaces.Repositories;
using MenuService.Command.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Persistence.Repositories
{
    public class MenuItemRepository(MenuServiceCommandDbContext dbContext) : BaseRepository<MenuItem>(dbContext), IMenuItemRepository
    {
    }
}
