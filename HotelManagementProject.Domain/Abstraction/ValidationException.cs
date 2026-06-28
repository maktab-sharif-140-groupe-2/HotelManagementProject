using HotelManagementProject.Domain.Common;

namespace HotelManagementProject.Domain.Abstraction;

public class ValidationException : BaseException
{
    public ValidationException(string message, string code) : base(message, code)
    {

    }

}
