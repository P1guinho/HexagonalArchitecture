using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infra.Data.Context
{
    public class InMemoryContext : DbContext
    {
        public InMemoryContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
