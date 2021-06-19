using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleApiDocker.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApiDocker.DataAccess.Mapping
{
    public sealed class EventMap : IEntityTypeConfiguration<EventEntitie>
    {
        public void Configure(EntityTypeBuilder<EventEntitie> builder)
        {
            builder.ToTable("Event");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.DateStart)
                .IsRequired();

            builder.Property(x => x.DateEnd)
                .IsRequired();

            builder.Property(x => x.DateInserted);

            builder.Property(x => x.DateUpdated);


            builder.HasIndex(x => x.Id).IsUnique();


            builder.HasData(InitializeData());
        }

        private List<EventEntitie> InitializeData()
        {
            List<EventEntitie> ret = new List<EventEntitie>();
            ret.Add(new EventEntitie()
            {
                Id = Guid.NewGuid(),
                Name = "ST PATRICK'S DAY",
                DateEnd = DateTime.MaxValue,
                DateStart = DateTime.MinValue
            });

            return ret;
        }
    }
}
