using Bogus;
using Core.Models;

namespace DbSeeder.TestEntitiesGenerators;

public class SheriffEntityGenerator : AbstractPartyGenerator
{
    public SheriffEntityGenerator()
    {
        this._mockPartyEntity = new Faker<PartyEntity>()
            .RuleFor(o => o.Company, f => $"{f.Address.County()} Sheriffs Department")
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