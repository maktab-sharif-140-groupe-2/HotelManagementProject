using HotelManagementProject.Domain.Abstraction;

namespace HotelManagementProject.Domain.Entites;

public class Room : BaseEntity
{
    public Room(int roomNumber, decimal pricePerNight, Guid hotelId)
    {
        RoomNumber = roomNumber;
        PricePerNight = pricePerNight;
        HotelId = hotelId;
        Validation();
    }

    public int RoomNumber { get; private set; }
    public decimal PricePerNight { get; private set; }
    public Guid HotelId { get; private set; }
    public Hotel Hotel { get; private set; }
    public ICollection<Booking> Bookings { get; private set; } = new List<Booking>();

    protected override void Validation()
    {
        if (RoomNumber < 0)
            throw new InvalidDataException("Room Number can't be negative");
        if (PricePerNight < 0)
            throw new InvalidDataException("Price can't be negative");
    }

    public void UpdateInfo(decimal pricePerNight, Guid hotelId)
    {
        PricePerNight=newPrice;
        Update();
        return this;

    }

    public void AddBooking(Booking booking)
    {
        Bookings.Add(booking);
    }
}
