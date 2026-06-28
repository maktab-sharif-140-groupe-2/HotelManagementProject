using HotelManagementProject.Domain.Common;

namespace HotelMangement_Service.Exceptions;

public class ApplicationException : BaseException
{
    public ApplicationException(ErrorModel errorModel, Exception? innerException = null) : base(errorModel, innerException)
    {
    }

    public ApplicationException(string message, string code, Exception? innerException = null) : base(message, code, innerException)
    {
    }
}
