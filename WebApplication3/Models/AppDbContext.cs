using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

public class AppDbContext : DbContext {
    public DbSet<ContactEntity> Type { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }
    private String DbPath { get; set; }

    public AppDbContext() {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>().HasOne<OrganizationEntity>(c => c.Organization).WithMany(or => or.Contact)
            .HasForeignKey(con => con.OrganizationId);

        modelBuilder.Entity<OrganizationEntity>().ToTable("organiztions").HasData(
            new OrganizationEntity()
            {
                Id = 101,
                Name = "wsei",
                Nip = "123123123",
                REGON = "1234123412341234"
            },
            new OrganizationEntity()
            {
                Id = 102,
                Name = "pkp",
                Nip = "12389123",
                REGON = "123987612341234"
            }
        );
        modelBuilder.Entity<OrganizationEntity>().OwnsOne(o => o.Address).HasData(
            new
            { City="Kraków",Street="Św. Filipa17",OrganizationEntityId=101 },
            new
            { City="Warszawa",Street="Złota 66",OrganizationEntityId=102 }
            );
        
        modelBuilder.Entity<ContactEntity>().ToTable("contacts").HasData(
            new ContactEntity() {
                Id = 1, 
                Name = "Jan",
                Surname = "Kowalski",
                Email = "",
                PhoneNumber = "123 456 789",
                BirthDate = new DateOnly(1990, 1, 1),
                Created = DateTime.Now,
                OrganizationId = 101
            },
            new ContactEntity() {
                Id = 2,
                Name = "Anna",
                Surname = "Nowak",
                Email = "", 
                PhoneNumber = "987 654 321",
                BirthDate = new DateOnly(1995, 5, 5),
                Created = DateTime.Now,
                OrganizationId = 101
            }, new ContactEntity() {
                Id = 3, 
                Name = "Piotr", 
                Surname = "Wiśniewski",
                Email = "", 
                PhoneNumber = "456 789 123",
                BirthDate = new DateOnly(2000, 10, 10),
                Created = DateTime.Now,
                OrganizationId = 102
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}