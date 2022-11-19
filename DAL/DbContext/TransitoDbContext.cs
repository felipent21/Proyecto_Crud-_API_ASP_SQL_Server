using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTransito.DAL.DbContext
{
    using ApiTransito.DAL.Entities;
    using Microsoft.EntityFrameworkCore;
    public class TransitoDbContext:DbContext
    {

        public TransitoDbContext(DbContextOptions<TransitoDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Matriculas> Matriculas { get; set; }
        public virtual DbSet<Conductores> Conductores { get; set; }
        public virtual DbSet<Sanciones> Sanciones { get; set; }



    }
}
