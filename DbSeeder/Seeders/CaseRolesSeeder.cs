using Core;
using Core.Models;

namespace DbSeeder.Seeders;

public static class CaseRolesSeeder
{
    public static List<CaseEntityRole> Seed(AppDbContext context)
    {
        List<CaseEntityRole> caseEntityRoles = new List<CaseEntityRole>();
        string[] roles = { "Family Law", "Small Claims", "Criminal", "Property Law" };

        foreach (var role in roles)
        {
            var caseRole = new CaseEntityRole();
            caseRole.Name = role;
            context.Add(caseRole);
            caseEntityRoles.Add(caseRole);
        }

        context.SaveChanges();
        return caseEntityRoles;
    }
}