using HotelManagementProject.Domain.Entites;

namespace HotelManagementProject.Domain.Intefacies;
public interface IGuestRepository
{
    Task<List<Guest>> GetGuests();
    Task<Guest> GetGuest(Guid id);
    Task<bool> AddGuest(Guest Guest);
    Task<bool> UpdateGuest(Guid id, Guest Guest);
    Task<bool> Delete(Guid id);

}
