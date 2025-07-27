namespace Core.Models;

public class CasePartyTag : BaseModel
{
   public CaseEntity CaseEntity { get; set; }
   public PartyEntity PartyEntity { get; set; }
   public PartyEntityRole PartyRole { get; set; }

   public CasePartyTag()
   {
   }

   public CasePartyTag(CaseEntity caseEntity, PartyEntity partyEntity, PartyEntityRole partyRole)
   {  
      this.CaseEntity = caseEntity;
      this.PartyEntity = partyEntity;
      this.PartyRole = partyRole;
   }
}