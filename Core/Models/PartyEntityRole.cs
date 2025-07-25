using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class PartyEntityRole : BaseModel
{
    public string Name { get; set; }

    public List<PartyEntity> Persons { get; set; }
}