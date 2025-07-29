using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public abstract class BaseModel
{
    [Key]
    public Guid Id { get; set; }
    public DateOnly DateCreated { get; set; }
    public DateOnly? DateUpdated { get; set; }

    public BaseModel()
    {
        Id = Guid.NewGuid();
    }
}