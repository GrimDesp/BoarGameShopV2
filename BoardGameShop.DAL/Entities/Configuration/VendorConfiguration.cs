using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameShop.DAL.Entities.Configuration
{
    internal class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasMany(c => c.Orders)
                .WithOne(o => o.VendorNavigation)
                .HasForeignKey(c => c.VendorId);
        }
    }
}
