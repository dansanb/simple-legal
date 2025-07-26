using Bogus;
using Core;
using Core.Models;

namespace DbSeeder.Seeders;

public static class CaseStatusRolesSeeder
{
    public static List<CaseEntityStatusRole> Seed(AppDbContext context, List<CaseEntityRole> caseRoles)
    {
        var caseEntityStatusRoles = new List<CaseEntityStatusRole>();
        var codes = new[]
            { "Filed", "Discovery", "Answer", "Active", "Dismissed", "Settled", "Appeal", "Judgment", "Complete" };

        foreach (var caseRole in caseRoles)
        {
            foreach (var code in codes)
            {
                var statusRole = new CaseEntityStatusRole()
                {
                    Name = code,
                    Role = caseRole
                };
                context.Add(statusRole);
                caseEntityStatusRoles.Add(statusRole);
            }
        }

        context.SaveChanges();

        return caseEntityStatusRoles;
    }
}