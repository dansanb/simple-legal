using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core;

public class AppDbContext : DbContext
{
    public DbSet<Core.Models.CaseEntity> Cases { get; set; }
    public DbSet<Core.Models.CaseEntityRole> CaseRoles { get; set; }
    public DbSet<Core.Models.CaseEntityNote> CaseNotes { get; set; }
    public DbSet<Core.Models.CaseEntityStatusRole> CaseStatusRoles { get; set; }
    public DbSet<Core.Models.CasePartyTag> CasePartyTags { get; set; }
    public DbSet<Core.Models.PartyEntity> Parties { get; set; }
    public DbSet<Core.Models.PartyEntityRole> PartyRoles { get; set; }

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