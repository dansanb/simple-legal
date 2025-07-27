using Bogus;
using Core.Models;
using DbSeeder.Seeders;

namespace DbSeeder.TestEntitiesGenerators;

public class PersonEntityGenerator : AbstractPartyGenerator
{
    public PersonEntityGenerator()
    {
        List<PartyEntityRole> possibleRoles = new List<PartyEntityRole>(
        [
            PartyRolesSeeder.PlaintiffPartyRole,
            PartyRolesSeeder.DefendantPartyRole,
        ]);
        this._mockPartyEntity = new Faker<PartyEntity>()
            .RuleFor(o => o.Role, f => f.PickRandom(possibleRoles))
            .RuleFor(o => o.FirstName, f => f.Person.FirstName)
            .RuleFor(o => o.LastName, f => f.Person.LastName)
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