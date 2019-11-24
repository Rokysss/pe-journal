using PEJournal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEJournal.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }

        public DbSet<Student> Students { get; set; }
    }
}
