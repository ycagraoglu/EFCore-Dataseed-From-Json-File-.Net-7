using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Data.EFCore.Configurations
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(125).IsRequired();
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.CityId).IsRequired();

            builder.HasOne(s => s.City).WithMany(g => g.Towns).HasForeignKey(s => s.CityId).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Towns");
        }
    }
}
