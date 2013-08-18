using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeJewels.Models;

namespace CodeJewels.Data
{
    public class CodeJewelsContext : DbContext
    {
        public CodeJewelsContext()
            : base("CodeJewelsDb")
        { 
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
