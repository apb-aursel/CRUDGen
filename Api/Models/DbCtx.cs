using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUDGen.Models
{
    public partial class DbCtx : DbContext
    {
        public DbCtx()
        {
        }

        public DbCtx(DbContextOptions<DbCtx> options)
            : base(options)
        {
        }

        public virtual DbSet<ARQDemo_Inetum> ARQDemo_Inetum { get; set; } = null!;
        public virtual DbSet<ARQDemo_Inetum_Idioma> ARQDemo_Inetum_Idioma { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }
        }
    }
}
