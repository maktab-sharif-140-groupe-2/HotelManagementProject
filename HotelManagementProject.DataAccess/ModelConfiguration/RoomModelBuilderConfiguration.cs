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
    public class RoomModelBuilderConfiguration : BaseModelConfiguration<Room>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Room> builder)
        {
            builder.Property(r => r.PricePerNight).HasColumnType("DECIMAL").IsRequired();
            builder.Property(r => r.RoomNumber).HasColumnType("INTEGER").IsRequired();
            builder.HasIndex(r => r.RoomNumber);


            builder.HasOne(r=>r.Hotel).WithMany(h=> h.Rooms).HasForeignKey(r=> r.HotelId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
