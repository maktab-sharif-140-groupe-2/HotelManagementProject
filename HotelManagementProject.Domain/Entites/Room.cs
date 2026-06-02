using HotelManagementProject.Domain.Abstraction;

namespace HotelManagementProject.Domain.Entites;

public class Room : BaseEntity
{
    public int RoomNumber { get; set; }
    public decimal PricePerNight { get; set; }
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public ICollection<Booking> Bookings { get; set; }=new List<Booking>();

    protected override void Validation()
    {
        throw new NotImplementedException();
    }
}
