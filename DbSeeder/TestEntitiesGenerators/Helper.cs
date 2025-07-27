using Core.Models;

namespace DbSeeder.Seeders;

public static class Helper
{
    private static Random Random = new Random();

    public static PartyEntity GetCompanyOrPerson()
    {
        if (Random.Next(0, 2) == 0) return GetRandomParty(PartySeeder.Companies);

        return GetRandomParty(PartySeeder.People);
    }

    public static PartyEntity GetRandomParty(List<PartyEntity> parties)
    {
        return parties.ElementAt(Random.Next(0, parties.Count));
    }
}