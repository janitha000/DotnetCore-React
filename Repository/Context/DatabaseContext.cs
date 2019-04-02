using Microsoft.EntityFrameworkCore;
using React.Entity;

namespace React.Repository.Context
{
    public class DatabaseContext : DbContext 
    {
        public DbSet<User> Users {get; set;}
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}