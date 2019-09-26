using System.Collections.Generic;
using System.Linq;
using ToDoApi.Models;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Controllers;

namespace ToDoApi.Contexts
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ToDo> ToDos { get; set; }

        
    }
}