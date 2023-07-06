using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScaffoldProject.Models;

namespace ScaffoldProject.Data
{
    public class ScaffoldProjectContext : DbContext
    {
        public ScaffoldProjectContext (DbContextOptions<ScaffoldProjectContext> options)
            : base(options)
        {
        }

        public DbSet<ScaffoldProject.Models.ItemListModel> ItemListModel { get; set; } = default!;
    }
}
