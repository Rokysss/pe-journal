using PEJournal.Models;
using System.Data.Entity;

namespace PEJournal.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<Student> Students { get; set; }
    }
}
