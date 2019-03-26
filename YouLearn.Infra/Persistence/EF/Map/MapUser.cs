using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouLearn.Domain.Entitties;
using YouLearn.Domain.ValueObject;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //table
            builder.ToTable("User");
            
            //Pk
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Senha).HasMaxLength(36).IsRequired();

            //Mapping value object
            builder.OwnsOne<Nome>(x => x.Nome, cb =>
                {
                    cb.Property(x => x.FirstName).HasMaxLength(50).HasColumnName("FirstName").IsRequired();
                    cb.Property(x => x.LastName).HasMaxLength(50).HasColumnName("LastName").IsRequired();
                });

            builder.OwnsOne<Email>(x => x.Email, cb =>
            {
                cb.Property(x => x.Endereco).HasMaxLength(50).HasColumnName("Email").IsRequired();
            });
        }
    }
}
