using HotelManagementProject.Domain.Entites;
using HotelMangement_Service.Dto.Response.RoomEntity;
using Mapster;

namespace HotelMangement_Service.Mapper;

public class RoomMapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Room, RoomDto>();
    }
}
