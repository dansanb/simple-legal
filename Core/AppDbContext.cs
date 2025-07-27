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
    DbSet<PartyEntity> Parties { get; set; }
    DbSet<PartyEntityRole> PartyRoles { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        string sqlDateCreatedFunction = "CURRENT_TIMESTAMP";

        modelBuilder.Entity<CaseEntity>()
            .Property(p => p.DateCreated)
            .HasDefaultValueSql(sqlDateCreatedFunction);

        modelBuilder.Entity<CaseEntityNote>()
            .Property(p => p.DateCreated)
            .HasDefaultValueSql(sqlDateCreatedFunction);

        modelBuilder.Entity<CaseEntityRole>()
            .Property(p => p.DateCreated)
            .HasDefaultValueSql(sqlDateCreatedFunction);

        modelBuilder.Entity<CaseEntityStatusRole>()
            .Property(p => p.DateCreated)
            .HasDefaultValueSql(sqlDateCreatedFunction);

        modelBuilder.Entity<CasePartyTag>()
            .Property(p => p.DateCreated)
            .HasDefaultValueSql(sqlDateCreatedFunction);

        modelBuilder.Entity<PartyEntity>()
            .Property(p => p.DateCreated)
            .HasDefaultValueSql(sqlDateCreatedFunction);

        modelBuilder.Entity<PartyEntityRole>()
            .Property(p => p.DateCreated)
            .HasDefaultValueSql(sqlDateCreatedFunction);
    }
}