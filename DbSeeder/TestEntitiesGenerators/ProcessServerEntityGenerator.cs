using Bogus;
using Core.Models;
using DbSeeder.Seeders;

namespace DbSeeder.TestEntitiesGenerators;

public class ProcessServerEntityGenerator : AbstractPartyGenerator
{
    public ProcessServerEntityGenerator()
    {
        this._mockPartyEntity = new Faker<PartyEntity>()
            .RuleFor(o => o.DateCreated, Helper.GetRandomDate())
            .RuleFor(o => o.PartyRole, PartyRolesSeeder.ProcessServerPartyRole)
            .RuleFor(o => o.Company, f => $"{f.Company.CompanyName()} Process Servers")
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(o => o.Address, f => f.Address.StreetAddress())
            .RuleFor(o => o.City, f => f.Address.City())
            .RuleFor(o => o.State, f => f.Address.State());
    }

    public override PartyEntity Generate()
    {
        return _mockPartyEntity.Generate();
    }
}