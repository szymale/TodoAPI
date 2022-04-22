using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> opt) : base(opt)
        {            
        }
       
        public DbSet<Todo> Todos { get; set; }
    }
}
