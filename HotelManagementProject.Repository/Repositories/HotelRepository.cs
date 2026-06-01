using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain.Dtos;
using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HotelManagementProject.Repository.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly AppDbContext _context;
    public async Task<bool> AddHotelAsync(Hotel Hotel)
    {
       var add= await _context.Hotels.AddAsync(Hotel);
      return await _context.SaveChangesAsync()>0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var hotel =await GetById(id);
         _context.Hotels.Remove(hotel);
        
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Hotel> GetByIdAsync(Guid id)
    {
        return await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task<Hotel> GetHotelAsync(Guid id)
    {
        return await _context.Hotels.FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<List<Hotel>> GetHotelsAsync()
    {
        return await _context.Hotels.Where(x=>!x.IsDeleted).ToListAsync();
    }

    public async Task<bool> UpdateHotelAsync(Guid id, HotelUpdateDto Hotel)
    {
        var hotel = await GetByIdAsync(id);
        if (hotel == null)
            return false;
        hotel.City= Hotel.City;
        hotel.Name=Hotel.Name;
        _context.Hotels.Update(hotel);
        return await _context.SaveChangesAsync() > 0;

    }
}
