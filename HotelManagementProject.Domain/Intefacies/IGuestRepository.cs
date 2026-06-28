
using HotelManagementProject.Domain.Entites;

namespace HotelManagementProject.Domain.Intefacies;

public interface IGuestRepository : IGenericRepository<Guest>
{
    Task<Guest?> GetGuestByUserNameAsync(string userName);
}
