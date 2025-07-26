using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class PartyEntity : BaseModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Company { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }

    public PartyEntityRole Role { get; set; }
}