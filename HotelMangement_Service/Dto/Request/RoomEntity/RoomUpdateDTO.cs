namespace HotelMangement_Service.Dto.Request.RoomEntity;

public class RoomUpdateDTO
{
    public int RoomId { get; set; }

    public decimal PricePerNight { get; set; }

    public int HotelId { get; set; }
}
