using System.ComponentModel.DataAnnotations;

namespace HotelManagementProject.Domain.Abstraction;
public abstract class BaseEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public bool IsDeleted { get; private set; }=false;
    public DateTime CreatedAt { get; private set; }= DateTime.Now;
    public DateTime? ModifiedAt { get; private set; }
    public BaseEntity Delete()
    {
        IsDeleted=true;
        ModifiedAt=DateTime.Now;
        return this;
    }

    public void Update()
    {
        ModifiedAt = DateTime.UtcNow;
    }

    protected abstract void Validation();
}
