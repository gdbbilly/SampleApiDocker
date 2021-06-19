using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SampleApiDocker.DataAccess
{
    public sealed class EFContext : DbContext
    {
        //public DbSet<InteractionEntitie> Interactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RemoveConventions(modelBuilder);

            //ADICIONAR OS MAPS PARA CRIAÇÃO DA BASE E DOS MIGRATIONS
            //modelBuilder.ApplyConfiguration(new InteractionMap());


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(BlinkerConfiguration.GetDefaultConnectionString());
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
