using Core.Models;

namespace Core.BusinessLayer;

public static class CaseHelper
{
    public static string GenerateCaseName(CaseEntity caseEntity)
    {
        if (caseEntity.Parties != null)
        {
            var plaintiff = caseEntity.Parties.FirstOrDefault(p => p.PartyRole.Name == "Plaintiff");
            var defendant = caseEntity.Parties.FirstOrDefault(p => p.PartyRole.Name == "Defendant");

            if (plaintiff != null && defendant != null)
            {
               string? p1 = string.IsNullOrEmpty(plaintiff.PartyEntity.Company)  ?
                   plaintiff.PartyEntity.LastName : plaintiff.PartyEntity.Company;

               string? p2 = string.IsNullOrEmpty(defendant.PartyEntity.Company)  ?
                   defendant.PartyEntity.LastName : defendant.PartyEntity.Company;

               if (p1 != null && p2 != null)
               {
                   return $"{p1} V {p2}";
               }
            }
        }
        return "";
    }

}