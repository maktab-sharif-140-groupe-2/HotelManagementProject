namespace HotelMangement_Service.Dto.Request.RoomEntity;

public class RoomUpdateDTO
{
    public Guid RoomId { get; set; }

    public decimal PricePerNight { get; set; }

    public Guid HotelId { get; set; }
}
