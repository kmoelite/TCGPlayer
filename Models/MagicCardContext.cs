using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TCGPlayerKevinMohan.Models
{
    public class MagicCardContext : DbContext
    {
        public DbSet<MagicCard> MagicCards { get; set; }

        public MagicCardContext() : base("TCGEntities")
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MyDefaultDbSchema");
        }
    }
} 