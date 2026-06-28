using HotelManagementProject.DataAccess.AppDbContextFile;

using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementProject.Repository.Repositories;

public class GuestRepository : GenericRepository<Guest>, IGuestRepository
{
    public GuestRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Guest?> GetGuestByUserNameAsync(string userName)
    {
        return await Entities.FirstOrDefaultAsync(x => x.UserName == userName);
    }
}
