using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class PartyEntityRole : BaseModel
{
    public string Name { get; set; }

    public List<PartyEntity> Parties { get; set; }

    public PartyEntityRole()
    {

    }

    public PartyEntityRole(string name)
    {
       Name = name;
    }
}