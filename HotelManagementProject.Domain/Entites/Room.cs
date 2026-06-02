using HotelManagementProject.Domain.Abstraction;

namespace HotelManagementProject.Domain.Entites;

public class Room : BaseEntity
{
    public Room(int roomNumber, decimal pricePerNight, int hotelId)
    {
        RoomNumber = roomNumber;
        PricePerNight = pricePerNight;
        HotelId = hotelId;
        Validation();
    }

    public int RoomNumber { get; set; }
    public decimal PricePerNight { get; set; }
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public ICollection<Booking> Bookings { get; set; }=new List<Booking>();

    protected override void Validation()
    {
        if (RoomNumber < 0)
            throw new InvalidDataException("Room Number can't be negative");
        if (PricePerNight < 0)
            throw new InvalidDataException("Price can't be negative");
    }
}
