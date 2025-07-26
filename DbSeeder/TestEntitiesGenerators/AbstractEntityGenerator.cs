using Bogus;
using Core.Models;

namespace DbSeeder.TestEntitiesGenerators;

public abstract class AbstractEntityGenerator<T>
{
    public abstract T Generate();
}

public abstract class AbstractPartyGenerator : AbstractEntityGenerator<PartyEntity>
{
    protected Faker<PartyEntity> _mockPartyEntity;
}