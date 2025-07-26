using Bogus;
using Core;
using Core.Models;

namespace DbSeeder.Seeders;

public static class PartyRolesSeeder
{
    public static List<PartyEntityRole> Seed(AppDbContext context)
    {
        var partyRoles = new List<PartyEntityRole>();
        var partyRoleNames = new[]
            { "Client", "Plaintiff", "Defendant", "Witness", "Attorney",
                "Law Firm", "Court", "Sheriff", "Process Server", "Vendor" };


        foreach (var partyRoleName in partyRoleNames)
        {
            var partyRole = new PartyEntityRole()
            {
                Name = partyRoleName
            };
            context.Add(partyRole);
            partyRoles.Add(partyRole);
        }

        context.SaveChanges();
        return partyRoles;
    }
}