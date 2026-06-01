using HotelManagementProject.Domain.Abstraction;

namespace HotelManagementProject.Domain.Entites;

public class Guest : BaseEntity
{
    public string FullName { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    protected override void Validation()
    {
        throw new NotImplementedException();
    }
}
