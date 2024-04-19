
namespace BoardGameShop.DAL.Entities.Configuration
{
    internal class VendorEmployeeConfiguration : IEntityTypeConfiguration<VendorEmployee>
    {
        public void Configure(EntityTypeBuilder<VendorEmployee> builder)
        {
            builder.HasKey(ve => ve.UserId);
            builder.HasOne(ve => ve.UserNavigation)
                .WithOne()
                .HasForeignKey<VendorEmployee>(ve => ve.UserId);
            builder.HasOne(ve => ve.VendorNavigation)
                .WithMany()
                .HasForeignKey(ve => ve.VendorId);
        }
    }
}
