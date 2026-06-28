namespace HotelManagementProject.Domain.Entites;

public class Booking : BaseEntity
{
  
    public Booking(Guid roomId, DateTime checkIn, DateTime checkOut, Guid guestId)
    {
        RoomId = roomId;
        CheckIn = checkIn;
        CheckOut = checkOut;
        GuestId = guestId;
        Validation();
    }

    public Guid RoomId { get; private set; }
    public Guid GuestId { get; private set; }
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
