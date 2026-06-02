namespace HotelManagementProject.Domain.Dtos.ServiceView;

public class RoomDto
{
    public int RoomNumber { get; set; }
    public decimal PricePerNight { get; set; }
    public Guid HotelId { get; set; }
}
