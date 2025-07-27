using Bogus;
using Core.Models;

namespace DbSeeder.TestEntitiesGenerators;

public class CaseNoteGenerator : AbstractEntityGenerator<CaseEntityNote>
{
    private readonly Faker<CaseEntityNote> _mockNote;

    public CaseNoteGenerator()
    {
        int minParagraphsPerNote = 1;
        int maxParagraphsPerNote = 3;
        var random = new Random();
        this._mockNote = new Faker<CaseEntityNote>()
            .RuleFor(o => o.Note, f => f.Lorem.Paragraphs(random.Next(minParagraphsPerNote, maxParagraphsPerNote + 1)));
    }

    public override CaseEntityNote Generate()
    {
        return _mockNote.Generate();
    }
}