namespace PFE_EMI.Models
{
    public class PFE
    {
        public int ID { get; set; }
        public int id_student { get; set; }
        public string id_prof { get; set; }
        public string lien_PFE { get; set; }
        public Etudiant Etudiant { get; set; }
        public Professeur Professeur { get; set; }

    }
}