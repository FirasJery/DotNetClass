namespace ApplicationCore.Domain
{
    public class Artiste
    {
        public int ArtisteId { get; set; }
        public string Contact { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Nationalite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        // objet de navigation
        public virtual List<Chanson> Chansons { get; set; }
        public virtual List<Concert> Concerts { get; set; }

    }
}
