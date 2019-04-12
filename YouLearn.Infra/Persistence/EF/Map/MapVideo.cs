using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouLearn.Domain.Entitties;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapVideo : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable("Video");

            //Fk
            builder.HasOne(x => x.UsuarioSugeriu).WithMany().HasForeignKey("UserId");
            builder.HasOne(x => x.Canal).WithMany().HasForeignKey("CanalId");
            builder.HasOne(x => x.Playlist).WithMany().HasForeignKey("PlayListId");

            //Properties 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Tags).HasMaxLength(100).IsRequired();
            builder.Property(x => x.OrdemNaPlaylist);
            //builder.Property(x => x.).HasMaxLength(200).IsRequired();
            builder.Property(x => x.IdVideoNoYouTube).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
