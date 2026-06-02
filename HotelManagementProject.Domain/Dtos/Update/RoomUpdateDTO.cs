using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementProject.Domain.Dtos.Update
{
    public class RoomUpdateDTO
    {
        public decimal PricePerNight { get; set; }
        public int HotelId { get; set; }
    }
}
