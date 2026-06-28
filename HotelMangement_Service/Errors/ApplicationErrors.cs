using HotelManagementProject.Domain.Common;

namespace HotelMangement_Service.Errors;

public class ApplicationErrors
{
    public static ErrorModel NotExsitingError(string propertyError) => new ErrorModel($"Entity {propertyError} Not Exist In System", "ApplicationException_900");
    public static ErrorModel HasRecordError(string propertyError) => new ErrorModel($"Entity {propertyError}  Existing In System", "ApplicationException_901");

}
