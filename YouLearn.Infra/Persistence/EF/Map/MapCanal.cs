using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouLearn.Domain.Entitties;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapCanal : IEntityTypeConfiguration<Canal>
    {
        public void Configure(EntityTypeBuilder<Canal> builder)
        {
            //table
            builder.ToTable("Canal");

            //Fk
            builder.HasOne(x => x.User).WithMany().HasForeignKey("UserId");

            //pk
            builder.HasKey(x => x.Id);
            //Mapping value object
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.UrlLogo).HasMaxLength(255).IsRequired();
        }
    }
}
