namespace HotelMangement_Service.Dto.Response.RoomEntity;

public class RoomDto
{
    public int RoomNumber { get; set; }
    public decimal PricePerNight { get; set; }
    public Guid HotelId { get; set; }
}
