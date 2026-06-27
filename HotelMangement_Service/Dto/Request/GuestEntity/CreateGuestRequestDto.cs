using System.ComponentModel.DataAnnotations;

namespace HotelMangement_Service.Dto.Request.GuestEntity;

public class CreateGuestRequestDto
{
    [Required(ErrorMessage = "full name is required",AllowEmptyStrings = false)]
    [MaxLength(50)]
    [MinLength(2)]
    public string FullName { get; private set; } = string.Empty;

    [Required(ErrorMessage = "national id is required", AllowEmptyStrings = false)]
    [MaxLength(10)]
    [MinLength(10)]
    public string NationalId { get; private set; } = string.Empty;

    [Required(ErrorMessage = "password is required", AllowEmptyStrings = false)]
    [MaxLength(8)]
    [MinLength(8)]
    public string Password { get; private set; } = string.Empty;

    [Required(ErrorMessage = "user name is required", AllowEmptyStrings = false)]
    [MaxLength(20)]
    [MinLength(2)]
    public string UserName { get; private set; } = string.Empty;
}
