using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using TodoApi.Models;


namespace TodoApi.Data
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<TodoContext>());
            }
        }

        public static void SeedData(TodoContext context)
        {
            Console.WriteLine("Applying Migrations...");

            context.Database.Migrate();

            if(!context.Todos.Any())
            {
                Console.WriteLine("Adding data - seeding...");

                context.Todos.AddRange(
                    new Todo() { Title = "Sample todo1", Description = "Automatically seeded data 1", ExpiryTime = DateTime.UtcNow.AddDays(2), IsFinished = false },
                    new Todo() { Title = "Sample todo2", Description = "Automatically seeded data 2", ExpiryTime = DateTime.UtcNow.AddDays(3), IsFinished = false },
                    new Todo() { Title = "Sample todo3", Description = "Automatically seeded data 3", ExpiryTime = DateTime.UtcNow.AddDays(4), IsFinished = false },
                    new Todo() { Title = "Sample todo4", Description = "Automatically seeded data 4", ExpiryTime = DateTime.UtcNow.AddDays(5), IsFinished = false },
                    new Todo() { Title = "Sample todo5", Description = "Automatically seeded data 5", ExpiryTime = DateTime.UtcNow.AddDays(6), IsFinished = false },
                    new Todo() { Title = "Sample todo6", Description = "Automatically seeded data 6", ExpiryTime = DateTime.UtcNow.AddDays(7), IsFinished = false }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data - not seeding.");
            }
        }
    }
}
