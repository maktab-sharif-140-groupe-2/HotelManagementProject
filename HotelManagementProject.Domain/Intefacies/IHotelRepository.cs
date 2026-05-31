using HotelManagementProject.Domain.Entites;

namespace HotelManagementProject.Domain.Intefacies;
public interface IHotelRepository
{
    Task<List<Hotel>> GetHotels();
    Task<Hotel?> GetHotel(Guid id);
    Task<bool> AddHotel(Hotel Hotel);
    Task<bool> UpdateHotel(Guid id, Hotel Hotel);
    Task<bool> Delete(Guid id);
    Task<Hotel> GetById(Guid id);


}
