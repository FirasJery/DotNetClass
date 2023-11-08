using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Domain
{
    public enum StyleMusicale
    {
        Classique, Pop, Rap, Rock
    }
    public class Chanson
    {

        public int ChansonId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateSortie { get; set; }
        public int Duree { get; set; }
        public StyleMusicale StyleMusicale { get; set; }
        [MaxLength(12)]
        [MinLength(3)]
        public string Title { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "VuesYoutube doit être un entier positif.")]
        public int VuesYoutube { get; set; }

        //objet de navigation
        public virtual Artiste Artiste { get; set; }
        [ForeignKey("Artiste")]
        public int ArtisteFk { get; set; }
    }
}
