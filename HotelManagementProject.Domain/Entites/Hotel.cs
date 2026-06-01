using HotelManagementProject.Domain.Abstraction;

namespace HotelManagementProject.Domain.Entites;

public class Hotel : BaseEntity
{
    public string Name { get; set; }
    public string City { get; set; }
    public ICollection<Room> Rooms { get; set; }=new List<Room>();

    protected override void Validation()
    {
        throw new NotImplementedException();
    }
}
