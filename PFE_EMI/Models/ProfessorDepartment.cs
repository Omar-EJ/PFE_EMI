namespace PFE_EMI.Models
{
    public class ProfessorDepartment
    {
        public string ID_prof { get; set; }
        public string ID_departement { get; set; }

        public Departement Departement { get; set; }
        public Professeur Professeur { get; set; }

    }
}