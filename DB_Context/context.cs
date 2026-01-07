using System.Data.Common;
using trekdle.Models.DB_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace trekdle.DB_Context;

public class DBContext : DbContext
{
    public DBContext (DbContextOptions<DBContext> options): base(options){}

    public DbSet<Admin> Admins { get; set; } 
    public DbSet<Wordle_Question> Questions {get; set;}
    public DbSet<Image> Images {get; set;}
    public DbSet<Daily_Questions> Daily_Questions{get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Admin>().ToTable("Admin")
        .HasIndex(a => a.Username) 
        .IsUnique();
        modelBuilder.Entity<Wordle_Question>().ToTable("Wordle_Question");
        modelBuilder.Entity<Image>().ToTable("Images");
        modelBuilder.Entity<Daily_Questions>().ToTable("Daily_Questions");
    }
}

