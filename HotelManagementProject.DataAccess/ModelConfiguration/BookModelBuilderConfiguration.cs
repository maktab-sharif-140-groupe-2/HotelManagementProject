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
    public class BookModelBuilderConfiguration : BaseModelConfiguration<Booking>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Booking> builder)
        {
            builder.HasOne(b => b.Room).WithMany(r => r.Bookings).HasForeignKey(r => r.RoomId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b => b.Guest).WithMany(g => g.Bookings).HasForeignKey(b => b.Guest.Id).OnDelete(DeleteBehavior.Restrict);

            builder.Property(b => b.CheckIn).HasColumnType("DATETIME2").IsRequired();
            builder.Property(b => b.CheckOut).HasColumnType("DATETIME2").IsRequired();
            
            

        }
    }
}
