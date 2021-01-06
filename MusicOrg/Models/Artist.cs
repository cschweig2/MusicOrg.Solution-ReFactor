using System;
using System.Collections.Generic;

namespace MusicOrg.Models
{
    public class Artist
    {
        public Artist()
        {
            this.Artists = new HashSet<ArtistVinyl>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ArtistVinyl> Vinyls { get; set; }

    }
}