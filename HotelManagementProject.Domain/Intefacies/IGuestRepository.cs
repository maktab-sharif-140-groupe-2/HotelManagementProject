using HotelManagementProject.Domain.Dtos;
using HotelManagementProject.Domain.Entites;

namespace HotelManagementProject.Domain.Intefacies;
public interface IGuestRepository
{
    Task<List<Guest>> GetGuestsAsync();
    Task<Guest?> GetGuestAsync(Guid id);
    Task<bool> AddGuestAsync(Guest Guest);
    Task<bool> UpdateGuestAsync(Guid id, GuestUpdateDto guestUpdateDto);
    Task<bool> DeleteAsync(Guid id);

}
