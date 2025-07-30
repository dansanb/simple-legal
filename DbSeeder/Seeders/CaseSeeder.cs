using Core;
using Core.BusinessLayer;
using Core.Models;

namespace DbSeeder.Seeders;

public static class CaseSeeder
{
    public static readonly List<CaseEntity> Cases = new List<CaseEntity>();
    private static readonly Random Random = new Random();

    public static void Seed(AppDbContext context)
    {
        int minCasesOfEachType = 500;
        int maxCasesOfEachType = 1000;
        var random = new Random();

        // create "random" amount of each case type
        foreach (var caseRole in CaseRolesSeeder.CaseRoles)
        {
            for (int i = 0; i < random.Next(minCasesOfEachType, maxCasesOfEachType); i++)
            {
                var caseEntity = new CaseEntity();
                caseEntity.Role = caseRole;
                caseEntity.DateCreated = Helper.GetRandomDate();
                caseEntity.StatusCode =
                    CaseStatusRolesSeeder.CaseStatusRoles.ElementAt(random.Next(0, CaseRolesSeeder.CaseRoles.Count));

                // add basic Party tag roles
                List<CasePartyTag> tags = new List<CasePartyTag>();

                // plaintiff
                var plaintiff = new CasePartyTag(caseEntity, Helper.GetCompanyOrPerson(),
                    PartyRolesSeeder.PlaintiffPartyRole);
                tags.Add(plaintiff);

                // defendant
                var defendant = new CasePartyTag(caseEntity, Helper.GetCompanyOrPerson(),
                    PartyRolesSeeder.DefendantPartyRole);
                tags.Add(defendant);

                // court
                tags.Add(new CasePartyTag(caseEntity, Helper.GetRandomParty(PartySeeder.Courts),
                    PartyRolesSeeder.CourtPartyRole));

                // attorneys
                tags.Add(new CasePartyTag(caseEntity, Helper.GetRandomParty(PartySeeder.People),
                    PartyRolesSeeder.AttorneyPartyRole));

                // opposing counsel
                tags.Add(new CasePartyTag(caseEntity, Helper.GetRandomParty(PartySeeder.LawFirms),
                    PartyRolesSeeder.OpposingCouncilPartyRole));

                // process server
                tags.Add(new CasePartyTag(caseEntity, Helper.GetRandomParty(PartySeeder.ProcessServers),
                    PartyRolesSeeder.ProcessServerPartyRole));

                caseEntity.Parties = tags;

                // give case a name of "Plaintiff v Defendant"
                caseEntity.Name = CaseHelper.GenerateCaseName(caseEntity);

                Cases.Add(caseEntity);
                context.Add(caseEntity);
            }
        }
    }
}