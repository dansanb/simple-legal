using Core;
using Core.Models;

namespace DbSeeder.Seeders;

public static class CasePartyTagRolesSeeder
{
    public static List<CasePartyTagRole> Seed(AppDbContext context)
    {
        var partyTags = new List<CasePartyTagRole>();
        var partyTagRole = new[]
            { "Plaintiff", "Defendant", "Witness", "Attorney", "Court", "Debtor", "Employer", "Opposing Council"};

        foreach (var tag in partyTagRole)
        {
            var tagRole = new CasePartyTagRole()
            {
                Name = tag
            };
            context.Add(tagRole);
            partyTags.Add(tagRole);
        }

        context.SaveChanges();
        return partyTags;
    }
}