using ArqsiP1.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<PlayerSchema> Player { get; set; }
        public DbSet<ConnectionSchema> Connection { get; set; }

        public DbSet<TagSchema> Tag { get; set; }

        public DbSet<IntroductionSchema> Introduction { get; set; }
    }
}
    
