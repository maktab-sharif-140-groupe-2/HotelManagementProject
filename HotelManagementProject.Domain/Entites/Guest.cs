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
            throw new ArgumentNullException("FullName Can't be null",nameof(FullName));
    }
    private void ValidateNationalCode(string nationalCode)
    {
        if (string.IsNullOrWhiteSpace(nationalCode))
            throw new ArgumentNullException("your NationalCode cannot be null or empty");

        if (nationalCode.Length != 10)
            throw new InvalidOperationException("the national code length is less or higher than 10 characters");

        if (!nationalCode.All(char.IsDigit))
            throw new InvalidOperationException("for thee national code all characters must be digit");
    }
    public void AddBooking(Booking booking)
    {
        Bookings.Add(booking);
    }

}
