namespace Core.Models;

public class CaseEntity : BaseModel
{
    public string Name { get; set; }

    public CaseEntityRole CaseRole { get; set; }
    public CaseEntityStatusRole? StatusCode { get; set; }
    public List<CaseEntityNote>? Notes { get; set; }
    public List<CasePartyTag>? Parties { get; set; }
}