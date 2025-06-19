using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1 , Name = "Chair" , DisplayOrder = 1},
                new Category {Id = 2 , Name = "Desk" , DisplayOrder = 2},
                new Category {Id = 3 , Name = "Bed" , DisplayOrder = 3},
                new Category {Id = 4 , Name = "Table" , DisplayOrder = 4}
            );
        }
    }
}