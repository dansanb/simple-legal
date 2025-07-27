using Core;
using Core.Models;

namespace DbSeeder.Seeders;

public static class CaseRolesSeeder
{
    public static readonly List<CaseEntityRole> CaseRoles = new List<CaseEntityRole>();
    public static void Seed(AppDbContext context)
    {
        string[] roles = { "Family Law", "Small Claims", "Criminal", "Property Law" };

        foreach (var role in roles)
        {
            var caseRole = new CaseEntityRole();
            caseRole.Name = role;
            context.Add(caseRole);
            CaseRoles.Add(caseRole);
        }

        context.SaveChanges();
    }
}