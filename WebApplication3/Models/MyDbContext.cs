using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() :base ("Name=constr")
        {

        }
        public DbSet <Products> Products { get; set; }
    }
}