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
                new Professeur{Fname = "BELOUADHA",Lname = "Fatima Zahra",ID_prof= "benlouadha",Disponible = 0},
                new Professeur{Fname = "KABBAJ",Lname = "Mohamed Issam",ID_prof= "kabbaj",Disponible = 1},
                new Professeur{Fname = "HASBI",Lname = "Abderrahim",ID_prof= "hasbi",Disponible = 1},
               
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
                new Etudiant{Fname = "AIT BEN EL ARBI",Lname = "Anass",Email= "anassaitbenelarbi@student.emi.ac.ma",ID=12345,Branch="INF",Specialty="SI"},
                new Etudiant{Fname = "EL JALAOUI",Lname = "Omar",Email= "omareljalaoui@student.emi.ac.ma",ID=123456,Branch="INF",Specialty="SI"}
            };

            foreach (var stud in Etudiants){
                context.Etudiants.Add(stud);
            }

            context.SaveChanges();

            var Prof_dept = new ProfessorDepartment[]{
                new ProfessorDepartment{ID_departement="INF",ID_prof="belouadha"},
                new ProfessorDepartment{ID_departement="INF",ID_prof="kabbaj"}
            }; 

            foreach (var prof_dept in Prof_dept)
            {
                context.ProfessorDepartment.Add(prof_dept);
            }

            context.SaveChanges();

            context.PFEs.Add(new PFE {id_prof="kabbaj",id_student= 12345, lien_PFE="https://wwww.google.com", sujet = "Delivery Optimizer" });
            context.PFEs.Add(new PFE { id_prof = "kabbaj", id_student = 123456, lien_PFE = "https://wwww.google.com", sujet = "Delivery Optimizer" });
            context.SaveChanges();

            context.DemandeEncadrements.Add(new DemandeEncadrements {
                date_depot = new DateTime(2020, 04, 01, 10, 00, 03),
                ID_Etudiant = 12345,
                ID_Prof = "kabbaj",
                ETAT = 0,
                liens_complementaires = "https://www.google.com,https://www.thexcoders.net,https://www.youtube.com",
                SujetPFE = "développement d'une platforme pour réduire le temps d'execution d'attente des packets d'une entreprise de livraison"
            });

            context.DemandeEncadrements.Add(new DemandeEncadrements
            {
                date_depot = new DateTime(2020, 04, 01, 16, 16, 44),
                ID_Etudiant = 12345,
                ETAT = 0,
                ID_Prof = "benlouadha",
                liens_complementaires = "https://www.google.com",
                SujetPFE = "développement d'une platforme pour réduire le temps d'execution d'attente des packets d'une entreprise de livraison"
            });

            context.DemandeEncadrements.Add(new DemandeEncadrements
            {
                date_depot = new DateTime(2020, 04, 01, 16, 20, 44),
                ID_Etudiant = 12345,
                ETAT = 0,
                ID_Prof = "hasbi",
                liens_complementaires = "https://www.google.com",
                SujetPFE = "développement d'une platforme pour réduire le temps d'execution d'attente des packets d'une entreprise de livraison"
            });

            context.SaveChanges();

            context.RemarqueProf.Add(new RemarqueProf
            {
                id_prof = "kabbaj",
                id_student = 12345,
                date_remarque = new DateTime(2020, 05, 15, 16, 16, 44),
                remarque = "Refaire l'étude des technologies ( techno u tilisé non justifié)",
                liens_complementaires = "",
                seen = true
            });

            context.RemarqueProf.Add(new RemarqueProf
            {
                id_prof = "kabbaj",
                id_student = 12345,
                date_remarque = new DateTime(2020, 05, 15, 20, 16, 44),
                remarque = "le plan de la présentation",
                liens_complementaires = "https://www.youtube.com,https://scholar.google.com",
                seen = false
            });

            context.SaveChanges();


        }
    }
}
