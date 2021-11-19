using Microsoft.EntityFrameworkCore;
using NoteAPI.Models;

namespace NoteAPI.DataAccess {
    public class NoteDbContext : DbContext {
        
        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base (options) { }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DBName;Integrated Security=True");
        // }

        public DbSet<Note> Notes { get; set; }

        
    }
}