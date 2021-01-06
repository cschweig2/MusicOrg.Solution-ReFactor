using System.Collections.Generic;
using System;

namespace MusicOrg.Models
{
    public class Vinyl
    {
        public Vinyl()
        {
            this.Artists = new HashSet<ArtistVinyl>();
        }
        public int VinylId { get; set; }
        public string Title { get; set; }
        public ICollection<ArtistVinyl> Artists { get; }
    }
}