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
    public class GuestModelBUilderConfiguration : BaseModelConfiguration<Guest>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Guest> builder)
        {
            builder.Property(g => g.FullName).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(g => g.NationalId).HasColumnType("NVARCHAR").HasMaxLength(10).IsRequired();
            builder.Property(g => g.ModifiedAt).HasColumnType("DATETIME2");
            
            
            builder.HasIndex(g => g.NationalId).IsUnique();
            
        }
    }
}
