namespace HotelMangement_Service.Dto.Request.RoomEntity;

public class CreateRoomDto
{
    public int RoomNumber { get; set; }
    public decimal PricePerNight { get; set; }
    public int HotelId { get; set; }
}
