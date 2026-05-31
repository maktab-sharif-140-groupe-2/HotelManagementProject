using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain.Dtos;
using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementProject.Repository.Repositories;

public class GuestRepository : IGuestRepository
{
    private readonly AppDbContext _appContext;
    private readonly DbSet<Guest> _guests;

    public GuestRepository(AppDbContext appContext)
    {
        _appContext = appContext;
        _guests = _appContext.Guests;
    }

    public async Task<bool> AddGuestAsync(Guest Guest)
    {
        await _guests.AddAsync(Guest);

        return await _appContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var guest = await _guests.FindAsync(id);

        if (guest == null)
            return false;

        _guests.Remove(guest);

        return await _appContext.SaveChangesAsync() > 0;
    }

    public async Task<Guest?> GetGuestAsync(Guid id)
    {
        return await _guests.FindAsync(id);
    }

    public async Task<List<Guest>> GetGuestsAsync()
    {
        return await _guests.ToListAsync();
    }

    public async Task<bool> UpdateGuestAsync(Guid id, GuestUpdateDto guestUpdateDto)
    {
        var guest = await _guests.FindAsync(id);

        if (guest == null)
            return false;

        guest.FullName = guestUpdateDto.FullName;

        return await _appContext.SaveChangesAsync() > 0;
    }
}
