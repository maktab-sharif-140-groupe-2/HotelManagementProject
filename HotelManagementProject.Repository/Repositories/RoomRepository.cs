using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain;
using HotelManagementProject.Domain.Dtos;
using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementProject.Repository.Repositories;

public class RoomRepository : GenericRepository<Room>, IRoomRepository
{
    public RoomRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
