using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAssignmentsContext
{
    public partial class AssignmentsContext : DbContext, IContext
    {
        public AssignmentsContext()
        {
        }

        public AssignmentsContext(DbContextOptions<AssignmentsContext> options)
            : base(options)
        {
        }
        public DbSet<Assignment> Assignments {get; set;}
        public DbSet<AssignmentType> AssignmentsTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=AssignmentsDB;Trusted_Connection = True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Hebrew_CI_AI");

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(a => a.Id).HasName("PK_Asignment");

                entity.ToTable("Asignment");
            }); 
            
            modelBuilder.Entity<AssignmentType>(entity =>
            {
                entity.HasKey(a => a.Id).HasName("PK_AsignmentType");

                entity.ToTable("AsignmentType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
