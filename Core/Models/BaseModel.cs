using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public abstract class BaseModel
{
    [Key]
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
}