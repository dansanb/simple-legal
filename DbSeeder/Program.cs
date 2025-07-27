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

        // Note: seeding has to be performed in the correct order because:
        //  - Records depend on other records to exists first.
        //  - Records need access to previously created records to
        //    create relationships.
        //
        // To make seeding easier, each entity seeder is a static class
        // with public lists of created entities so that other seeders
        // have access to previously created records.
        using (var context = new AppDbContext(optionsBuilder.Options))
        {
            // seed all the roles first
            CaseRolesSeeder.Seed(context);
            CaseStatusRolesSeeder.Seed(context);
            PartyRolesSeeder.Seed(context);

            // create some parties
            PartySeeder.Seed(context);

            // create cases
            CaseSeeder.Seed(context);

            // add notes to cases
            CaseNotesSeeder.Seed(context);
        }
    }
}