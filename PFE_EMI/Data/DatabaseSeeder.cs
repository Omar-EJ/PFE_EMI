using PFE_EMI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_EMI.Data
{
    public class DatabaseSeeder
    {
        public static void init(PFEContext context)
        {
            context.Database.EnsureCreated();
            if (context.Etudiants.Any())
            {
                return;
            }

            var Professors = new Professeur[]{
                new Professeur{Fname = "BELOUADHA",Lname = "Fatima Zahra",ID= "benlouadha",Disponible = 0},
                new Professeur{Fname = "KABBAJ",Lname = "Mohamed Issam",ID= "kabbaj",Disponible = 1}
         };
            foreach (var prof in Professors)
            {
                context.Professeurs.Add(prof);
            }
            context.SaveChanges();



            var dept = new Departement { nom = "Informatique", code_ID = "INF", ID_chef = "belouadha" };
            var specialty = new Specialty { name = "système d'information", code_dept = "INF", ID_specialty="SI" };

            context.Departement.Add(dept);
            context.SaveChanges();

            context.Specialtys.Add(specialty);
            context.SaveChanges();
            var Etudiants = new Etudiant[]{
                new Etudiant{Fname = "AIT BEN EL ARBI",Lname = "Anass",Email= "anassaitbenelarbi@student.emi.ac.ma",ID=12345},
                new Etudiant{Fname = "EL JALAOUI",Lname = "Omar",Email= "omareljalaoui@student.emi.ac.ma",ID=123456}
            };

            foreach (var stud in Etudiants)
            {
                context.Etudiants.Add(stud);
            }
            context.SaveChanges();

            var Prof_dept = new ProfessorDepartment[]
            {
                new ProfessorDepartment{ID_departement="INF",ID_prof="belouadha"},
                new ProfessorDepartment{ID_departement="INF",ID_prof="kabbaj"}
            }; foreach (var prof_dept in Prof_dept)
            {
                context.ProfessorDepartment.Add(prof_dept);
            }
            context.SaveChanges();

            context.PFEs.Add(new PFE {ID = 123,id_prof="kabbaj",id_student= 12345,lien_PFE="https://wwww.google.com"  });
            context.PFEs.Add(new PFE { ID = 124, id_prof = "kabbaj", id_student = 123456, lien_PFE = "https://wwww.google.com" });
            context.SaveChanges();


        }
    }
}
