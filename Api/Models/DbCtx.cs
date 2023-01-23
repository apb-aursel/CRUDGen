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

        public virtual DbSet<ARQ_EXPEDIENT> ARQ_EXPEDIENT { get; set; } = null!;
        public virtual DbSet<ARQ_EXPEDIENT_I> ARQ_EXPEDIENT_I { get; set; } = null!;
    }
}
