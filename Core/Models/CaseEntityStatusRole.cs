using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class CaseEntityStatusRole : BaseModel
{
    public string Name { get; set; }

    public CaseEntityRole CaseRole { get; set; }
}