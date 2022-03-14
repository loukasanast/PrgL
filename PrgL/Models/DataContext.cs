using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrgL.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Language> Languages { get; set; }
    }
}
