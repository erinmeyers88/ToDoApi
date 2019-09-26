using ToDoApi.Models;
using Microsoft.EntityFrameworkCore;

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