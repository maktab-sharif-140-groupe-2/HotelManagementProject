using HotelManagementProject.Domain.Entites;
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
            builder.
        }
    }
}
