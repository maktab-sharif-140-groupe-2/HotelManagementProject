using HotelManagementProject.Domain.Abstraction;

namespace HotelManagementProject.Domain.Entites;

public class Guest : BaseEntity
{
    public Guest(string fullName, string nationalId)
    {
        FullName = fullName;
        NationalId = nationalId;
        Validation();
        ValidateNationalCode(NationalId);
    }

    public string FullName { get;private set; }
    public string NationalId { get; private set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    protected override void Validation()
    {
        if(string.IsNullOrEmpty(FullName))
            throw new DomainException(DomainErrors.NullOrWithSpeaceError("Guest Fullname"));
    }
    private void ValidateNationalCode(string nationalCode)
    {
        if (string.IsNullOrWhiteSpace(nationalCode))
            throw new DomainException(DomainErrors.NullOrWithSpeaceError("NationalCode"));

        if (nationalCode.Length != 10)
            throw new DomainException(DomainErrors.InvalidCharcterLengthError("NationalCode"));

        if (!nationalCode.All(char.IsDigit))
            throw new DomainException(DomainErrors.BeNumberError("NationalCode"));
    }
    public void AddBooking(Booking booking)
    {
        Bookings.Add(booking);
    }

}
