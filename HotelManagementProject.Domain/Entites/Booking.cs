using HotelManagementProject.Domain.Abstraction;

namespace HotelManagementProject.Domain.Entites;

public class Booking : BaseEntity
{
    public Booking(Guid roomId, DateOnly checkIn, DateOnly checkOut)
    {
        RoomId = roomId;
        CheckIn = checkIn;
        CheckOut = checkOut;
        Validation();
    }
    
    public Guid RoomId { get; private set; }
    public DateOnly CheckIn { get; private set; }
    public DateOnly CheckOut { get; private set; }
    public Guest Guest { get; private set; }
    public Room Room { get; private set; }

    protected override void Validation()
    {
        if (CheckIn >= CheckOut)
            throw new InvalidDataException("CheckIn can't be farther CheckOut ");
    }
 
}
