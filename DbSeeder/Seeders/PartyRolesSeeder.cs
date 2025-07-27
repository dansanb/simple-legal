using Bogus;
using Core;
using Core.Models;

namespace DbSeeder.Seeders;

public static class PartyRolesSeeder
{
    public static readonly PartyEntityRole PlaintiffPartyRole = new PartyEntityRole("Plaintiff");
    public static readonly PartyEntityRole DefendantPartyRole = new PartyEntityRole("Defendant");
    public static readonly PartyEntityRole CourtPartyRole = new PartyEntityRole("Court");
    public static readonly PartyEntityRole AttorneyPartyRole = new PartyEntityRole("Attorney");
    public static readonly PartyEntityRole OpposingCouncilPartyRole = new PartyEntityRole("Opposing Council");
    public static readonly PartyEntityRole ProcessServerPartyRole = new PartyEntityRole("Process Server");
    public static readonly PartyEntityRole WitnessPartyRole = new PartyEntityRole("Witness");
    public static readonly PartyEntityRole DebtorPartyRole = new PartyEntityRole("Debtor");
    public static readonly PartyEntityRole EmployerPartyRole = new PartyEntityRole("Employer");
    public static readonly PartyEntityRole SheriffPartyRole = new PartyEntityRole("Sheriff");
    public static void Seed(AppDbContext context)
    {
        context.Add(PlaintiffPartyRole);
        context.Add(DefendantPartyRole);
        context.Add(CourtPartyRole);
        context.Add(AttorneyPartyRole);
        context.Add(OpposingCouncilPartyRole);
        context.Add(ProcessServerPartyRole);
        context.Add(WitnessPartyRole);
        context.Add(DebtorPartyRole);
        context.Add(EmployerPartyRole);
        context.Add(SheriffPartyRole);

        context.SaveChanges();
    }
}