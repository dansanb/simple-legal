namespace Core.Models;

public class CaseEntityNote : BaseModel
{
    public string Note { get; set; }
    public CaseEntity CaseEntity { get; set; }
}