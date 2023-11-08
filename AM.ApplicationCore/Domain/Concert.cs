namespace ApplicationCore.Domain
{
    public class Concert
    {


        public double Cachet { get; set; }
        public DateTime DateConcert { get; set; }
        public int Duree { get; set; }

        public int ArtisteFK { get; set; }
        public Artiste Artiste { get; set; }

        public int FestivalFK { get; set; }
        public Festival Festival { get; set; }


    }
}
