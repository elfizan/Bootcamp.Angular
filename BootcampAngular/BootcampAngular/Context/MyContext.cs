using BootcampAngular.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BootcampAngular.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyContext") { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}