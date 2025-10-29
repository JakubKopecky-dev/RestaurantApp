using MenuService.Command.Application.Interfaces.Repositories;
using MenuService.Command.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Persistence.Repositories
{
    public class MenuRepository(MenuServiceCommandDbContext dbContext) : BaseRepository<Menu>(dbContext), IMenuRepository  
    {
    }
}
