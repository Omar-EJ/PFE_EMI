using Microsoft.EntityFrameworkCore;
using PFE_EMI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PFE_EMI.Models.Display;

namespace PFE_EMI.Data
{
    public class PFEContext : DbContext
    {
        public PFEContext(DbContextOptions<PFEContext> options) : base(options)
        {
        }

        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }
        public DbSet<Departement> Departement { get; set; }
        public DbSet<PFE> PFEs { get; set; }
        public DbSet<ProfessorDepartment> ProfessorDepartment { get; set; }
        public DbSet<RemarqueProf> RemarqueProf { get; set; }
        public DbSet<Specialty> Specialtys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etudiant>().HasOne(e => e.PFE).WithOne(p => p.Etudiant).HasForeignKey<PFE>(p => p.id_student);
            modelBuilder.Entity<Etudiant>().ToTable("Etudiant");
            modelBuilder.Entity<Professeur>().ToTable("Professeur");
            modelBuilder.Entity<Departement>().ToTable("Departement");
            modelBuilder.Entity<PFE>().ToTable("PFE");
            modelBuilder.Entity<ProfessorDepartment>().ToTable("ProfessorDepartment");
            modelBuilder.Entity<RemarqueProf>().ToTable("RemarquesProf");
            modelBuilder.Entity<DemandeEncadrements>().ToTable("DemandesEncadrements");
            modelBuilder.Entity<Specialty>().ToTable("Specialite");
        }

        public DbSet<PFE_EMI.Models.DemandeEncadrements> DemandeEncadrements { get; set; }

        public DbSet<PFE_EMI.Models.Display.DemandeEncadrant> DemandeEncadrant { get; set; }


    }


}
