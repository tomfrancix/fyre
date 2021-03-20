using Fyre.Console.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Fyre.Console.Data
{
    public class Context : DbContext
    {
        public DbSet<List> Lists { get; set; }
        public DbSet<Note> Notes { get; set; }

        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Fyre;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        // Use 'Add-Migration NameOfMigration' to update migrations folder after model changes.
        // Use 'Update-Database -verbose' to update the database with those new migrations.
    }
}
