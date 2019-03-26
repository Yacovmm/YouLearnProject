using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouLearn.Domain.Entitties;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapPlayList : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable("PlayList");
            
            //Fk
            builder.HasOne(x => x.User).WithMany().HasForeignKey("UserId");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
        }
    }
}
