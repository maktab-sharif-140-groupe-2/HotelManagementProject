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
    
    public int RoomId { get; private set; }
    public DateTime CheckIn { get; private set; }
    public DateTime CheckOut { get; private set; }
    public Guest Guest { get; private set; }
    public Room Room { get; private set; }

    protected override void Validation()
    {
        if (CheckIn >= CheckOut)
            throw new InvalidDataException("CheckIn can't be farther CheckOut ");
    }
 
}
