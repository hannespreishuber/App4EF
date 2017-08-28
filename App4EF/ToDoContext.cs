using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App4EF
{
    class ToDoContext:DbContext
    {
       public DbSet<ToDo> ToDos { get; set; }

        //public ToDoContext(DbContextOptions<ToDoContext> options)
        //   : base(options)


        public ToDoContext()
        {

//              Database.EnsureCreated();
//            Database.Migrate();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = desktop-k0ag27t; Initial Catalog = tododb; User Id = sa; Password = ppedvsa; ");
            //    @"Server=localhost;Initial Catalog=Northwind;Trusted_Connection=True;");

        }

    }
}
