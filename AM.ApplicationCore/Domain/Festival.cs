namespace ApplicationCore.Domain
{
    public class Festival
    {


        public int FestivalId { get; set; }
        public int Capacite { get; set; }
        public string Label { get; set; }
        public string Ville { get; set; }

        // objet de navigation

        public virtual List<Concert> Concerts { get; set; }
    }
}
