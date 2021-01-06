namespace MusicOrg.Models
{
    public class ArtistVinyl
    {
        public int ArtistVinylId { get; set; }
        public int ArtistId { get; set; }
        public int VinylId { get; set; }
        public Artist Artist { get; set; }
        public Vinyl Vinyl { get; set; }
    }
}