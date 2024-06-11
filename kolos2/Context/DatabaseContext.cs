using kolos2.Models;

using Microsoft.EntityFrameworkCore;

namespace kolos2.Conext;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
        
    }
    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=master;User Id=SA;Password=yourStrong(!)Password;TrustServerCertificate=True;");
    }
    public DbSet<BackpackSlot> BackpackSlots { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Character>().HasData(new Character
        {
            CharacterId = 1,
            FirstName = "Test",
            LastName = "Test",
            CurrentWeight = 1,
            MaxWeight = 3,
            Money = 1
            
        });
        
        modelBuilder.Entity<Item>().HasData(new Item
        {
            ItemId = 1,
            Name = "Test",
            Weight = 1
        });
        modelBuilder.Entity<Title>().HasData(new Title
        {
            TitleId = 1,
            Nam = "Test"
        });
        modelBuilder.Entity<BackpackSlot>().HasData(new BackpackSlot
        {
            BackpackSlotId = 1,
            ItemId = 1,
            CharacterId = 1
        });
        modelBuilder.Entity<CharacterTitle>().HasData(new CharacterTitle
        {
            CharacterId = 1,
            TitleId = 1,
            AquireAt = DateTime.Now
        });
        
    }
    
    
}