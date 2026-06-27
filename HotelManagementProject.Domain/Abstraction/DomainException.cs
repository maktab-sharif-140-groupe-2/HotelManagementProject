using HotelManagementProject.Domain.Common;

namespace HotelManagementProject.Domain.Abstraction;

public class DomainException : BaseException
{
    public DomainException(ErrorModel errorModel, Exception? innerException = null) : base(errorModel, innerException)
    {
    }

    public DomainException(string message, string code,Exception? innerException=null) : base(message, code,innerException)
    {

    }

}
