using Bogus;
using Core;
using Core.Models;
using DbSeeder.TestEntitiesGenerators;

namespace DbSeeder.Seeders;

public static class PartySeeder
{
    public static readonly List<PartyEntity> Courts = new List<PartyEntity>();
    public static readonly List<PartyEntity> ProcessServers = new List<PartyEntity>();
    public static readonly List<PartyEntity> Sheriffs = new List<PartyEntity>();
    public static readonly List<PartyEntity> LawFirms = new List<PartyEntity>();
    public static readonly List<PartyEntity> People = new List<PartyEntity>();
    public static readonly List<PartyEntity> Companies = new List<PartyEntity>();

    public static void Seed(AppDbContext context)
    {
        var random = new Random();
        int minPartiesOfEachType = 8;
        int maxPartiesOfEachType = 15;

        var courtGenerator = new CourtEntityGenerator();
        var processServerGenerator = new ProcessServerEntityGenerator();
        var sheriffGenerator = new SheriffEntityGenerator();
        var lawFirmGenerator = new LawFirmEntityGenerator();
        var personGenerator = new PersonEntityGenerator();
        var companyGenerator = new CompanyEntityGenerator();

        // courts
        for (int i = 0; i < random.Next(minPartiesOfEachType, maxPartiesOfEachType); i++)
        {
            var party = courtGenerator.Generate();
            context.Add(party);
            Courts.Add(party);
        }

        // process servers
        for (int i = 0; i < random.Next(minPartiesOfEachType, maxPartiesOfEachType); i++)
        {
            var party = processServerGenerator.Generate();
            context.Add(party);
            ProcessServers.Add(party);
        }

        // sheriffs
        for (int i = 0; i < random.Next(minPartiesOfEachType, maxPartiesOfEachType); i++)
        {
            var party = sheriffGenerator.Generate();
            context.Add(party);
            Sheriffs.Add(party);
        }

        // law firms
        for (int i = 0; i < random.Next(minPartiesOfEachType, maxPartiesOfEachType); i++)
        {
            var party = lawFirmGenerator.Generate();
            context.Add(party);
            LawFirms.Add(party);
        }

        // individuals
        for (int i = 0; i < random.Next(minPartiesOfEachType, maxPartiesOfEachType); i++)
        {
            var party = personGenerator.Generate();
            context.Add(party);
            People.Add(party);
        }

        // companies
        for (int i = 0; i < random.Next(minPartiesOfEachType, maxPartiesOfEachType); i++)
        {
            var party = companyGenerator.Generate();
            context.Add(party);
            Companies.Add(party);
        }

        context.SaveChanges();
    }
}