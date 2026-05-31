using HotelManagementProject.Domain.Dtos;
using HotelManagementProject.Domain.Entites;

namespace HotelManagementProject.Domain.Intefacies;
public interface IHotelRepository
{
    Task<List<Hotel>> GetHotelsAsync();
    Task<Hotel?> GetHotelAsync(Guid id);
    Task<bool> AddHotelAsync(Hotel Hotel);
    Task<bool> UpdateHotelAsync(Guid id, HotelUpdateDto Hotel);
    Task<bool> DeleteAsync(Guid id);
    Task<Hotel> GetByIdAsync(Guid id);


}
