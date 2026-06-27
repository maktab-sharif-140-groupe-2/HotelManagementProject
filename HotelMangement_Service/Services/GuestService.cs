using HotelManagementProject.Domain.Entites;
using HotelManagementProject.Domain.Intefacies;
using HotelMangement_Service.Dto.Request.GuestEntity;
using HotelMangement_Service.Interfaces;
using HotelMangement_Service.PasswordHashingService;
using MapsterMapper;

namespace HotelMangement_Service.Services;

public class GuestService : IGuestService
{
    private readonly IGuestRepository _guestRepository;

    public GuestService(IGuestRepository guestRepository, IMapper mapper)
    {
        _guestRepository = guestRepository;
    }

    public async Task<bool> LoginAsync(LoginRequestDto loginRequestDto)
    {
        var user = await _guestRepository.GetGuestByUserNameAsync(loginRequestDto.UserName);

        if (user is null)
            throw new InvalidOperationException($"user name or password is invalid!!");

        var passwordIsValid = PasswordHashing.VerifyPassword(loginRequestDto.Password, user.PasswordHash);

        if (!passwordIsValid)
            throw new InvalidOperationException($"user name or password is invalid!!");

        return true;
    }

    public async Task<bool> RegisterGuestAsync(CreateGuestRequestDto createGuestRequest)
    {
        var isExist = await _guestRepository.AnyAsync(g => g.UserName == createGuestRequest.UserName);

        if (!isExist)
            throw new InvalidOperationException("the user name is exist!!!");

        var hashedPassword = PasswordHashing.HashPassword(createGuestRequest.Password);

        var guest = new Guest(createGuestRequest.FullName, createGuestRequest.NationalId, hashedPassword, createGuestRequest.UserName);

        var result = await _guestRepository.AddAsync(guest);

        if (!result)
            throw new InvalidOperationException("something went wrong in add register guest");

        return result;
    }
}
