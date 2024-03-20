using Microsoft.EntityFrameworkCore;
using ToDoList2.Models;

namespace ToDoList2.Data
{
    public class AppllicationDbContext : DbContext
    {
        public DbSet<ListItem> ListItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string? builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(builder);
        }
    }
}
