using HotelMangement_Service.Dto.Request.GuestEntity;

namespace HotelMangement_Service.Interfaces;

public interface IGuestService
{
    Task<bool> RegisterGuestAsync(CreateGuestRequestDto createGuestRequest);

    Task<bool> LoginAsync(LoginRequestDto loginRequestDto);

}
