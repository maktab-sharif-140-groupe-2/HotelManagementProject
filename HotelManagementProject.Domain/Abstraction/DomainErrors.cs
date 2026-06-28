using HotelManagementProject.Domain.Common;

namespace HotelManagementProject.Domain.Abstraction;

public class DomainErrors
{
    public static ErrorModel InvalidCheckoutTimeError()=> new ErrorModel("CheckIn can't be farther CheckOut","DomainException_800");
    public static ErrorModel NullOrWithSpeaceError(string propertyName)=> new ErrorModel($"{propertyName} Can't be null", "DomainException_801");
    public static ErrorModel InvalidCharcterLengthError(string propertyName)=> new ErrorModel($"the {propertyName}  length is less or higher From Valid Format", "DomainException_802");
    public static ErrorModel BeNumberError(string propertyName)=> new ErrorModel($"the {propertyName} Requirment To Be Number", "DomainException_803");
    public static ErrorModel NegativeError(string propertyName)=> new ErrorModel($"the {propertyName} Requirment To Positive", "DomainException_804");
}
