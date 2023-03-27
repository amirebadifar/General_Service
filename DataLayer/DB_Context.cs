using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Table;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DB_Context : DbContext
    {
        public DB_Context(DbContextOptions option) : base(option) { }

        #region Table

        public DbSet<AboutTable> About { get; set; }
        public DbSet<ContactTable> Contacts { get; set; }
        public DbSet<InsertProductTable> InsertProducts { get; set; }
        public DbSet<InsertServiceTable> InsertServices { get; set; }
        public DbSet<ProductTable> Products { get; set; }
        public DbSet<QuestionsTable> Questions { get; set; }
        public DbSet<ServiceTable> Services { get; set; }
        public DbSet<WorkSampleTable> WorkSamples { get; set; }

        #endregion
    }
}
