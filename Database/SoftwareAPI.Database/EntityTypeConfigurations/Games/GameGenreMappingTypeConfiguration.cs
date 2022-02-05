namespace SoftwareAPI.Database.EntityTypeConfigurations.Games
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftwareAPI.Database.Models.Software;
    using System;

    public class GameGenreMappingTypeConfiguration : IEntityTypeConfiguration<GameGenreMapping>
    {
        public void Configure(EntityTypeBuilder<GameGenreMapping> builder)
        {

            builder
                    .HasIndex(nameof(GameGenreMapping.GameId), nameof(GameGenreMapping.GenreId))
                    .IsUnique(true);

            builder
                    .HasOne(ggm => ggm.Game)
                    .WithMany(ga => ga.Genres)
                    .HasForeignKey(ggm => ggm.GameId);

            builder
                    .HasOne(ggm => ggm.Genre)
                    .WithMany(ge => ge.Games)
                    .HasForeignKey(ggm => ggm.GenreId);
          
        }
    }
}
