using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HotelManagementProject.Repository.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly AppDbContext _context;
    public async Task<bool> AddHotel(Hotel Hotel)
    {
       var add= await _context.Hotels.AddAsync(Hotel);
      return await _context.SaveChangesAsync()>0;
    }

    public async Task<bool> Delete(Guid id)
    {
        var hotel =await GetById(id);
         _context.Hotels.Remove(hotel);
        
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Hotel> GetById(Guid id)
    {
        return await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task<Hotel> GetHotel(Guid id)
    {
        return await _context.Hotels.FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<List<Hotel>> GetHotels()
    {
        return await _context.Hotels.Where(x=>!x.IsDeleted).ToListAsync();
    }

    public Task<bool> UpdateHotel(Guid id, Hotel Hotel)
    {
        _context.Hotels
    }
}
