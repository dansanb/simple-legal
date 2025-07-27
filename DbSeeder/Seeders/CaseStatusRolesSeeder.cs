using Bogus;
using Core;
using Core.Models;

namespace DbSeeder.Seeders;

public static class CaseStatusRolesSeeder
{
    public static readonly List<CaseEntityStatusRole> CaseStatusRoles = new List<CaseEntityStatusRole>();
    public static void Seed(AppDbContext context)
    {
        var codes = new[]
            { "Filed", "Discovery", "Answer", "Active", "Dismissed", "Settled", "Appeal", "Judgment", "Complete" };

        foreach (var caseRole in CaseRolesSeeder.CaseRoles)
        {
            foreach (var code in codes)
            {
                var statusRole = new CaseEntityStatusRole()
                {
                    Name = code,
                    Role = caseRole
                };
                context.Add(statusRole);
                CaseStatusRoles.Add(statusRole);
            }
        }
        context.SaveChanges();
    }
}