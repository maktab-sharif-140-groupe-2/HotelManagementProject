using HotelManagementProject.Domain.Abstraction;

namespace HotelManagementProject.Domain.Entites;

public class Hotel : BaseEntity
{
    public Hotel(string name, string city)
    {
        Name = name;
        City = city;
        Validation();
    }

    public string Name { get; private set; }
    public string City { get; private set; }
    public ICollection<Room> Rooms { get; private set; }=new List<Room>();

    protected override void Validation()
    {
        if(string.IsNullOrEmpty(Name))
            throw new DomainException(DomainErrors.NullOrWithSpeaceError("Hotel Name"));
        if(string.IsNullOrEmpty(City))
            throw new DomainException(DomainErrors.NullOrWithSpeaceError("City Name"));
    }
    public void AddRoom(Room room)
    {
          Rooms.Add(room);
    }
}
