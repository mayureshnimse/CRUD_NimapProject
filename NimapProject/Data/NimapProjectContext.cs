using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NimapProject.Model;

namespace NimapProject.Data
{
    public class NimapProjectContext : DbContext
    {
        public NimapProjectContext (DbContextOptions<NimapProjectContext> options)
            : base(options)
        {
        }

        public DbSet<NimapProject.Model.nimap> nimap { get; set; } = default!;
    }
}
