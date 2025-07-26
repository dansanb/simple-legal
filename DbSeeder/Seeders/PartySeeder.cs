using Bogus;
using Core;
using Core.Models;

namespace DbSeeder.Seeders;

public static class PartySeeder
{
    public static List<PartyEntity> Seed(AppDbContext context, List<PartyEntityRole> partyRoles)
    {
        var parties = new List<PartyEntity>();
        var random = new Random();

        var testCourt = new Faker<PartyEntity>()
            .RuleFor(o => o.Company, f => $"Court of {f.Address.County()}")
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Address, f => f.Address.StreetAddress())
            .RuleFor(o => o.City, f => f.Address.City())
            .RuleFor(o => o.State, f => f.Address.State());

        var testServer = new Faker<PartyEntity>()
            .RuleFor(o => o.Company, f => $"{f.Company.CompanyName()} Process Servers")
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Address, f => f.Address.StreetAddress())
            .RuleFor(o => o.City, f => f.Address.City())
            .RuleFor(o => o.State, f => f.Address.State());

        var testSheriff = new Faker<PartyEntity>()
            .RuleFor(o => o.Company, f => $"{f.Address.County()} Sheriffs Department")
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Address, f => f.Address.StreetAddress())
            .RuleFor(o => o.City, f => f.Address.City())
            .RuleFor(o => o.State, f => f.Address.State());

        var testLawFirm = new Faker<PartyEntity>()
            .RuleFor(o => o.Company, f => $"{f.Name.LastName()} Law Firm")
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Address, f => f.Address.StreetAddress())
            .RuleFor(o => o.City, f => f.Address.City())
            .RuleFor(o => o.State, f => f.Address.State());

        var testPerson = new Faker<PartyEntity>()
            .RuleFor(o => o.FirstName, f => f.Person.FirstName)
            .RuleFor(o => o.LastName, f => f.Person.LastName)
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Address, f => f.Address.StreetAddress())
            .RuleFor(o => o.City, f => f.Address.City())
            .RuleFor(o => o.State, f => f.Address.State());

        var testCompany = new Faker<PartyEntity>()
            .RuleFor(o => o.Company, f => f.Company.CompanyName())
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Address, f => f.Address.StreetAddress())
            .RuleFor(o => o.City, f => f.Address.City())
            .RuleFor(o => o.State, f => f.Address.State());


        foreach (var partyRole in partyRoles)
        {
            var party = new PartyEntity();
            for (int i=0; i < random.Next(10, 20); i++)
            {
                switch (partyRole.Name)
                {
                    case "Court":
                        party = testCourt.Generate();
                        break;
                    case "Process Server":
                        party = testServer.Generate();
                        break;
                    case "Sheriff":
                        party = testSheriff.Generate();
                        break;
                    case "Law Firm":
                        party = testSheriff.Generate();
                        break;
                    default:
                        party = testCompany.Generate();
                        if (random.Next(2) == 0)
                        {
                            party = testPerson.Generate();
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