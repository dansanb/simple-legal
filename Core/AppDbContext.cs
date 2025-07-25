using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core;

public class AppDbContext : DbContext
{
    DbSet<CaseEntity> Cases { get; set; }
    DbSet<CaseEntityRole> CaseRoles { get; set; }
    DbSet<CaseEntityNote> CaseNotes { get; set; }
    DbSet<CaseEntityStatusRole> CaseStatusRoles { get; set; }
    DbSet<CasePartyTag> CasePartyTags { get; set; }
    DbSet<CasePartyTagRole> CasePartyTagRoles { get; set; }
    DbSet<PartyEntity> Parties { get; set; }
    DbSet<PartyEntityRole> PartyRoles { get; set; }
}