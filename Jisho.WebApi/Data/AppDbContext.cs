using Jisho.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jisho.WebApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<DictionaryEntry> DictionaryEntries { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DictionaryEntry>()
            .HasIndex(x => x.Term);
        modelBuilder.Entity<DictionaryEntry>()
            .HasIndex(x => x.Reading);
        
        base.OnModelCreating(modelBuilder);
    }
}