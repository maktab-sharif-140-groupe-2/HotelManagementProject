using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain;
using HotelManagementProject.Domain.Dtos;
using HotelManagementProject.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementProject.Repository.Repositories;
public class RoomRepository
{
    private readonly AppDbContext _context;
    public async Task<bool> AddRoomAsync(Room Room)
    {
        var add = await _context.Rooms.AddAsync(Room);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var room = await GetByIdAsync(id);
        _context.Rooms.Remove(room);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Room> GetByIdAsync(Guid id)
    {
        return await _context.Rooms.FindAsync(id);
    }

    public async Task<Room> GetRoomAsync(Guid id)
    {
        return await _context.Rooms.FindAsync(id);
    }

    public async Task<List<Room>> GetRoomsAsync()
    {
        return await _context.Rooms.Where(x => !x.IsDeleted).ToListAsync();
    }

    public async Task<bool> UpdateRoomAsync(Guid id, RoomUpdateDTO Room)
    {
        var room = await GetByIdAsync(id);
        if (room == null)
            return false;
        room.PricePerNight = Room.PricePerNight;
        room.HotelId = Room.HotelId;
        _context.Rooms.Update(room);
        return await _context.SaveChangesAsync() > 0;
    }
}
