using Core;
using Core.Models;

namespace DbSeeder.Seeders;

public static class CaseSeeder
{
    public static List<CaseEntity> Seed(AppDbContext context, List<CaseEntityRole> caseRoles,
        List<CaseEntityStatusRole> caseStatusRoles, List<PartyEntity> parties, List<CasePartyTagRole> casePartyTagRoles)
    {
        throw new NotImplementedException();
        // var random = new Random();
        //
        // foreach (var caseRole in caseRoles)
        // {
        //     for (int i = 0; i < random.Next(3, 10); i++)
        //     {
        //
        //     }
        //
        // }
    }
}