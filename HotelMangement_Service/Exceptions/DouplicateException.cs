using HotelManagementProject.Domain.Common;

namespace HotelMangement_Service.Exceptions;

public class DouplicateException : ApplicationException
{
    public DouplicateException(ErrorModel errorModel, Exception? innerException = null) : base(errorModel, innerException)
    {
    }

    public DouplicateException(string message, string code, Exception? innerException = null) : base(message, code, innerException)
    {
    }
}
