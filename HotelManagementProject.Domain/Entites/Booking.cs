using HotelManagementProject.Domain.Abstraction;

namespace HotelManagementProject.Domain.Entites;

public class Booking : BaseEntity
{
    public Guest Guest { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }

    protected override void Validation()
    {
        throw new NotImplementedException();
    }
}
