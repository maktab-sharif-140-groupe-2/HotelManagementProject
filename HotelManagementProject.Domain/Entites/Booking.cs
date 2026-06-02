using HotelManagementProject.Domain.Abstraction;

namespace HotelManagementProject.Domain.Entites;

public class Booking : BaseEntity
{
    public Booking(int roomId, DateTime checkIn, DateTime checkOut)
    {
        RoomId = roomId;
        CheckIn = checkIn;
        CheckOut = checkOut;
        Validation();
    }

    public int RoomId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public Guest Guest { get; set; }
    public Room Room { get; set; }

    protected override void Validation()
    {
        if (CheckIn >= CheckOut)
            throw new InvalidDataException("CheckIn can't be farther CheckOut ");
    }
}
