namespace HotelManagementProject.Domain.Common;

public class BaseException:Exception
{
    public BaseException(string message,string code,Exception? innerException=null):base(message,innerException)
    {
        Code= code;
        
    }
    public BaseException(ErrorModel errorModel, Exception? innerException = null):base(errorModel.message,innerException) 
    {
        Code = errorModel.code;
        
    }
    public string Code { get; set; }
}
