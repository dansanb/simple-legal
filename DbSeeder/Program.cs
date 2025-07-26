using Core;
using Core.Models;
using DbSeeder.Seeders;
using Microsoft.EntityFrameworkCore;

namespace DbSeeder;

class Program
{
    static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=simplelegal;Username=postgres");

        using (var context = new AppDbContext(optionsBuilder.Options))
        {
            // seed all the roles first
            var caseRoles = CaseRolesSeeder.Seed(context);
            var caseStatusRoles = CaseStatusRolesSeeder.Seed(context);
            var partyRoles = PartyRolesSeeder.Seed(context);
            var casePartyTagRoles = CasePartyTagRolesSeeder.Seed(context);

            // create some parties
            var parties = PartySeeder.Seed(context, partyRoles);

            // create cases
            var cases = CaseSeeder.Seed(context, caseRoles, caseStatusRoles, parties, casePartyTagRoles);

            // add notes to cases
            var notes = CaseNotesSeeder.Seed(context, cases);

        }
    }
}