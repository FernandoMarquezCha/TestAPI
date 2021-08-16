using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Models
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {

        }
        public DbSet<Buildings> Buildings { get; set; }
        public DbSet<Customers> Customers { get; set; }

        public DbSet<PartNumbers> PartNumbers { get; set; }
       
    }
}
