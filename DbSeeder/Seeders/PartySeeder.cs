using Bogus;
using Core;
using Core.Models;
using DbSeeder.TestEntitiesGenerators;

namespace DbSeeder.Seeders;

public static class PartySeeder
{
    public static List<PartyEntity> Seed(AppDbContext context, List<PartyEntityRole> partyRoles)
    {
        var parties = new List<PartyEntity>();
        var random = new Random();

        var courtGenerator = new CourtEntityGenerator();
        var processServerGenerator = new ProcessServerEntityGenerator();
        var sheriffGenerator = new SheriffEntityGenerator();
        var lawFirmGenerator = new LawFirmEntityGenerator();
        var personGenerator = new PersonEntityGenerator();
        var companyGenerator = new CompanyEntityGenerator();


        foreach (var partyRole in partyRoles)
        {
            var party = new PartyEntity();
            for (int i=0; i < random.Next(10, 20); i++)
            {
                switch (partyRole.Name)
                {
                    case "Court":
                        party = courtGenerator.Generate();
                        break;
                    case "Process Server":
                        party = processServerGenerator.Generate();
                        break;
                    case "Sheriff":
                        party = sheriffGenerator.Generate();
                        break;
                    case "Law Firm":
                        party = lawFirmGenerator.Generate();
                        break;
                    default:
                        party = companyGenerator.Generate();
                        if (random.Next(2) == 0)
                        {
                            party = personGenerator.Generate();
                        }
                        break;
                }

                party.Role = partyRole;
                parties.Add(party);
                context.Add(party);
            }
        }

        context.SaveChanges();
        return parties;
    }
}