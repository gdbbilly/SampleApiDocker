using Microsoft.EntityFrameworkCore;
using System.Linq;
using SampleApiDocker.Entities;
using SampleApiDocker.DataAccess.Mapping;

namespace SampleApiDocker.DataAccess
{
    public sealed class EFContext : DbContext
    {
        public DbSet<EventEntitie> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RemoveConventions(modelBuilder);

            //Add Maps for DataBase Create and Migrations
            modelBuilder.ApplyConfiguration(new EventMap());


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sampleapidocker.database;Database=AppDbContext;User=sa;Password=sampleapidocker@123;");
        }

        private void RemoveConventions(ModelBuilder modelBuilder)
        {
            #region Remove convention cascade delete

            var cascadeFKs = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            #endregion
        }
    }
}
