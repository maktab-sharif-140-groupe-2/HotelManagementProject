using HotelManagementProject.Domain.Common;

namespace HotelMangement_Service.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(ErrorModel errorModel, Exception? innerException = null) : base(errorModel, innerException)
    {
    }

    public NotFoundException(string message, string code, Exception? innerException = null) : base(message, code, innerException)
    {
    }
}
