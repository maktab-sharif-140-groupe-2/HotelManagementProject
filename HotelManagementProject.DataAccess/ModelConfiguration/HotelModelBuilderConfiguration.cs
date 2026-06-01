using HotelManagementProject.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementProject.DataAccess.ModelConfiguration
{
    public class HotelModelBuilderConfiguration : BaseModelConfiguration<Hotel>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasMany(h => h.Rooms).WithOne(r => r.Hotel).HasForeignKey(r => r.Id);
            
            builder.Property(h=>h.City).HasColumnType("NVARCHAR").HasMaxLength(30).IsRequired();
            builder.Property(h=>h.Name).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();

            builder.HasIndex(h=> h.Name).IsUnique();
            
        }
    }
}
