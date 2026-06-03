using HotelManagementProject.Domain.Abstraction;

namespace HotelManagementProject.Domain.Entites;

public class Hotel : BaseEntity
{
    private Hotel()
    {
        
    }
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
            throw new ArgumentNullException("HotleName can't be null");
        if(string.IsNullOrEmpty(City))
            throw new ArgumentNullException("city can't be null");
    }
    public  bool AddRoomAsync(Room room)
    {
        if (Rooms.Any(x => x.RoomNumber == room.RoomNumber))
            throw new InvalidDataException("The Room Number is Exist ");
          Rooms.Add(room);
        return true;
    }
}
