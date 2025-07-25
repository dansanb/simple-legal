namespace Core.Models;

public class CasePartyTag : BaseModel
{
   public CaseEntity CaseEntity { get; set; }
   public PartyEntity PartyEntity { get; set; }
   public CasePartyTagRole TagRole { get; set; }
}