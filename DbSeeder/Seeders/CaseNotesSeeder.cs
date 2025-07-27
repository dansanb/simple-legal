using Core;
using Core.Models;
using DbSeeder.TestEntitiesGenerators;

namespace DbSeeder.Seeders;

public static class CaseNotesSeeder
{
    private static readonly Random Random = new Random();
    public static readonly List<CaseEntityNote> CaseNotes = new List<CaseEntityNote>();
    public static void Seed(AppDbContext context)
    {
        int minNotesForEachCase = 7;
        int maxNotesForEachCase = 21;

        var noteGenerator = new CaseNoteGenerator();
        foreach (var caseEntity in CaseSeeder.Cases)
        {
            for (int i = 0; i < Random.Next(minNotesForEachCase, maxNotesForEachCase); i++)
            {
               var note = noteGenerator.Generate();
               note.CaseEntity = caseEntity;
               CaseNotes.Add(note);
               context.Add(note);
            }
        }
        context.SaveChanges();
    }
}