using MenuService.Command.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Persistence
{
    public class MenuServiceCommandDbContext(DbContextOptions<MenuServiceCommandDbContext> options) : DbContext(options)
    {
        public DbSet<Menu> Menus { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<MenuItem>()
                .Property(i => i.UnitPrice)
                .HasPrecision(10, 2);





        }





    }
}
