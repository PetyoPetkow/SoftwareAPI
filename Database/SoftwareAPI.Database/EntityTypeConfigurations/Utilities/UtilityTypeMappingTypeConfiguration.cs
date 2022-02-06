namespace SoftwareAPI.Database.EntityTypeConfigurations.Utilities
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftwareAPI.Database.Models.Software;

    public class UtilityTypeMappingTypeConfiguration : IEntityTypeConfiguration<Utility>
    {

        public void Configure(EntityTypeBuilder<Utility> builder)
        {
            builder
                .HasOne<SoftwareAPI.Database.Models.Software.Type>(s => s.Type)
                .WithMany(t => t.Utilities)
                .HasForeignKey(u => u.TypeId);

        }
    }
}
